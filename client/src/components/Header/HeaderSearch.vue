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
        :fetch-suggestions="handleSearchBooks"
        :debounce="500"
        :trigger-on-focus="false"
        @select="showBookDetails"
        @focus="toggleSearch(true)"
      >
        <div slot-scope="{item}" class="search-preview-book">
          <img :src="$urlBaseApi + item.imageUrl" :alt="item.title" />
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
        @click="toggleSearch(true)"
      ></el-button>
    </div>
    <div class="overlay" @click="toggleSearch(false)"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { parseListBooks } from "@/common/helpers/Books";

export default Vue.extend({
  name: "header-search",
  data() {
    return {
      rawApiBooks: [] as object[],
      search: {
        value: "" as string,
        isFocused: false as boolean,
        openOnMobile: false as boolean
      }
    };
  },
  methods: {
    async handleSearchBooks(
      queryString: string,
      callback: (result) => void
    ): Promise<void> {
      const response = await this.$get(
        `/searchbooks?page=0&limit=100&search=${queryString}`
      );

      const { entity } = response;

      const bookResults = parseListBooks(entity);
      this.rawApiBooks = entity;

      if (bookResults.length === 0) {
        this.$message.error("Nenhum livro encontrado com os termos digitados!");
      }

      callback(bookResults);
    },
    showBookDetails(bookPreview): void {
      const { toggleSearch, rawApiBooks, $store } = this;

      const book = rawApiBooks.find(element => element.id === bookPreview.id);

      $store.commit("SHOW_BOOK_DETAILS", { book });

      toggleSearch(false);
    },
    toggleSearch(value: boolean): void {
      const { search } = this;
      search.isFocused = value;
      search.openOnMobile = value;
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
    font-size: 18px;
  }

  @media only screen and (max-width: $--width-size-mobile) {
    .input {
      margin: 0;
      width: calc(100% - 22px);
      position: fixed;
      left: 11px;
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
      line-height: 20px;
      white-space: normal;

      @media screen and (max-width: $--width-size-mobile) {
        font-size: 14px;
      }
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
    width: 100%;
  }
}
</style>


