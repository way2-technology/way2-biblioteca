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
        @select="showBookDetails"
        @focus="showSearch"
      >
        <div slot-scope="{item}" class="search-preview-book">
          <img :src="item.image" :alt="item.title" />
          <div>
            <h3>{{item.title}}</h3>
            <el-tag size="mini">{{item.category}}</el-tag>
          </div>
        </div>
      </el-autocomplete>
      <el-button class="toggle-mobile" type="text" icon="el-icon-search" @click="showSearch"></el-button>
    </div>
    <div class="overlay" @click="closeSearch(false)"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/providers/EventBus.js";

export default Vue.extend({
  name: "header-search",
  data() {
    return {
      rawApiBooks: [] as object[],
      search: {
        value: "" as string,
        isFocused: false as boolean,
        openOnMobile: false as boolean,
        booksResults: [] as object[]
      }
    };
  },
  methods: {
    async searchBooks(
      queryString: string,
      callback: (result) => void
    ): Promise<void> {
      await fetch(
        `https://www.googleapis.com/books/v1/volumes?q=${queryString}&startIndex=0&maxResults=5`
      )
        .then(res => res.json())
        .then(response => {
          const { items, totalItems } = response;

          if (items && items.length) {
            this.rawApiBooks = items;
            this.search.booksResults = this.parseBooks(items);
          }
        });

      callback(this.search.booksResults);
    },
    parseBooks(books: object[]): object[] {
      return books.map((book: any) => {
        const {
          id,
          volumeInfo: { categories, title, imageLinks }
        } = book;

        return {
          id,
          title,
          category:
            categories && typeof categories === "object"
              ? categories[0]
              : "General",
          image: imageLinks.thumbnail ? imageLinks.thumbnail : ""
        };
      });
    },
    showBookDetails(bookPreview: any): void {
      const { closeSearch, rawApiBooks } = this;

      closeSearch(false);

      const book = rawApiBooks.find(
        (element: any) => element.id === bookPreview.id
      );

      this["$store"].commit("SHOW_BOOK_DETAILS", { book });
    },
    showSearch() {
      const { search } = this;
      search.isFocused = true;
      search.openOnMobile = true;
    },
    closeSearch() {
      const { search } = this;
      search.isFocused = false;
      search.openOnMobile = false;
    }
  }
});
</script>

<style lang="scss">
.header__search {
  flex-grow: 1;

  .content {
    margin-left: 1.2rem;
    position: relative;
    display: flex;
    justify-content: flex-end;
    flex-grow: 1;
    transition: 0.2s;
  }

  .input {
    width: 100%;

    input[type="text"] {
      background: $--color-black-3;
      border-color: transparent;
      border-radius: 3px;
      transition: 0.2s;

      &:hover {
        box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
      }
    }
  }

  .overlay {
    opacity: 0;
    visibility: hidden;
    z-index: 8;
  }

  .toggle-mobile {
    display: none;
    color: #fff !important;
    font-size: 16px;
  }

  @media only screen and (max-width: 767px) {
    .input {
      margin: 0;
      width: calc(100% - 40px);
      position: fixed;
      left: 20px;
      top: 11px;
      z-index: 1;
      visibility: hidden;
      opacity: 0;
      transition: 0.2s;
    }

    .toggle-mobile {
      display: block;
    }

    &.header__search--mobile-open {
      .input {
        visibility: visible;
        opacity: 1;
      }
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

.el-scrollbar {
  .el-autocomplete-suggestion__wrap {
    max-height: 400px;
  }
}
</style>


