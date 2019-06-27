<template>
  <div
    class="header__search"
    :class="{
      'header__search--focused': search.isFocused,
      'header__search--mobile-open': search.openOnMobile
    }"
  >
    <div class="content">
      <el-autocomplete
        class="input"
        placeholder="Digite para buscar algum livro..."
        suffix-icon="el-icon-search"
        v-model="search.value"
        :fetch-suggestions="searchBooks"
        :debounce="500"
        :trigger-on-focus="false"
        @select="selectBookSearched"
        @focus="setSearchFocus(true)"
      >
        <div slot-scope="{item}" class="search-preview-book">
          <img :src="item.image" :alt="item.title">
          <div>
            <h3>{{item.title}}</h3>
            <el-tag size="mini">{{item.category}}</el-tag>
          </div>
        </div>
      </el-autocomplete>
      <el-button
        class="toggle-mobile"
        type="text"
        icon="el-icon-search"
        @click="toggleSearchMobile"
      ></el-button>
    </div>
    <div class="overlay" @click="setSearchFocus(false)"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data() {
    return {
      search: {
        value: "" as string,
        isFocused: false as boolean,
        openOnMobile: false as boolean,
        booksResults: [] as object[]
      }
    };
  },
  methods: {
    async searchBooks(queryString, callback): Promise<void> {
      await fetch(
        `https://www.googleapis.com/books/v1/volumes?q=${queryString}&startIndex=0&maxResults=5`
      )
        .then(res => res.json())
        .then(response => {
          const { items, totalItems } = response;

          if(items && items.length)
            this.search.booksResults = this.parseSearchedBooks(items);
        });

      callback(this.search.booksResults);
    },
    parseSearchedBooks(books: object[]): object[] {
      return books.map((book: any) => {
        const {
          id,
          volumeInfo: {
            categories,
            title,
            imageLinks: { thumbnail }
          }
        } = book;

        return {
          id,
          title,
          category:
            categories && typeof categories === "object"
              ? categories[0]
              : "General",
          image: thumbnail ? thumbnail : ""
        };
      });
    },
    selectBookSearched($book): void {
      alert(JSON.stringify($book));
    },
    setSearchFocus(value: boolean): void {
      this.search.isFocused = value;
    },
    toggleSearchMobile(): void {
      this.search.openOnMobile = !this.search.openOnMobile;
    }
  }
});
</script>

<style lang="scss">
.header__search {
  width: 100%;

  .content {
    margin-left: 1.2rem;
    position: relative;
    display: flex;
    justify-content: flex-end;
    flex-grow: 1;
    transition: 0.2s;

    > div {
      width: 100%;
    }
  }

  input[type="text"] {
    background: $--color-black-3;
    border-color: transparent;
    border-radius: 3px;
    transition: 0.2s;

    &:hover {
      box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
    }
  }

  .overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
    opacity: 0;
    visibility: hidden;
    transition: 0.2s;
    z-index: 8;
  }

  .toggle-mobile {
    display: none;
    color: #fff;
    font-size: 16px;
  }

  @media only screen and (max-width: 767px) {
    .input {
      display: none;
    }
    .toggle-mobile {
      display: block;
    }
  }
}

.header__search--focused {
  .content {
    z-index: 9;

    input[type="text"] {
      background: #fff;
    }
  }
  .overlay {
    opacity: 1;
    visibility: visible;
  }
}

.el-autocomplete-suggestion {
  li {
    padding: 15px !important;
    border-bottom: 1px solid #eee;

    &:last-child {
      border-bottom: 0;
    }

    > div {
      display: flex;
    }

    h3 {
      max-width: 405px;
      overflow: hidden;
      text-overflow: ellipsis;
      white-space: nowrap;
    }

    img {
      width: 65px;
      min-height: 95px;
      margin-right: 15px;
      border: 1px solid #ddd;
      border-radius: 3px;
    }
  }
}
</style>


