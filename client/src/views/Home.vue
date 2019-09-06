<template>
  <el-container class="home" v-loading="$loader.active && $loader.type === 'gettingBooks'">
    <div class="home__container">
      <div class="books">
        <template v-if="$loader.active && $loader.type === 'gettingBooks'">
          <BookPreviewSkeleton v-for="index in limitBooks" :key="index" />
        </template>
        <template v-else>
          <BookPreview
            v-for="(book, index) in booksPreview"
            :key="index"
            :book="book"
            @trigger-show-book="showBookDetails"
          />
        </template>
      </div>
      <div class="books-pagination" v-if="booksPreview.length > 0">
        <el-pagination
          background
          layout="prev, pager, next"
          :pager-count="5"
          :total="pagination.total"
          :current-page.sync="pagination.current"
          @current-change="getBooks"
        ></el-pagination>
      </div>
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/common/providers/EventBus";
import { BookPreview, BookPreviewSkeleton } from "@/components";
import { parseListBooks } from "@/common/helpers/Books";

export default Vue.extend({
  name: "home",
  components: {
    BookPreview,
    BookPreviewSkeleton
  },
  data: () => ({
    rawListBooks: [] as object[],
    booksPreview: [] as object[],
    pagination: {
      total: 0 as number,
      current: 0 as number
    }
  }),
  computed: {
    limitBooks(): number {
      return 12;
    },
    appElement(): HTMLDivElement | any {
      return document.querySelector("#app");
    }
  },
  created() {
    this.getBooks();
    this.listenEventFilter();
  },
  methods: {
    scrollToTop(): void {
      this.appElement.scrollTo({ top: 0, behavior: "smooth" });
    },
    async getBooks(): Promise<void> {
      const {
        getUrlBooksProcessed,
        scrollToTop,
        $getWithLoader,
        pagination: { current }
      } = this;

      const page = current <= 0 ? 0 : current - 1;

      const response = await $getWithLoader({
        url: getUrlBooksProcessed(page),
        typeLoader: "gettingBooks"
      });

      const { total, currentPage, entity } = response;

      this.rawListBooks = entity;
      this.booksPreview = parseListBooks(entity);
      this.pagination.total = total;

      scrollToTop();
    },
    getUrlBooksProcessed(page: number): string {
      const { limitBooks, getParamFilters } = this;

      const url = `/getbooks?limit=${limitBooks}&page=${page}`;

      return getParamFilters(url);
    },
    getParamFilters(url): string {
      const { categoriesSelected } = this.$store.state;

      if (!categoriesSelected || categoriesSelected.length === 0) {
        return url;
      }

      const categoriesIds = categoriesSelected.map(
        (category: any) => category.id
      );
      
      return `${url}&filters=[${categoriesIds}]`;
    },
    showBookDetails(id: number): void {
      const book = this.rawListBooks.find(element => element.id === id);

      this.$store.commit("SHOW_BOOK_DETAILS", { book });
    },
    listenEventFilter(): void {
      EventBus.$on("filter-books-by-categories", categoriesSelected => {
        this.resetPagination();
        this.getBooks();
      });
    },
    resetPagination(): void {
      this.pagination.current = 0;
    }
  }
});
</script>

<style lang="scss" scoped>
.home {
  display: flex;
  flex-direction: column;

  &__container {
    margin: 0 auto;
    width: 100%;
    max-width: $--width-container;
    padding: 16px;
    display: flex;
    flex-direction: column;
  }

  .books {
    min-height: calc(100vh - 120px);
    width: 100%;
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    grid-gap: 20px;
    position: relative;

    /deep/ .el-card {
      height: 100%;
    }
  }

  .books-pagination {
    margin: 40px 0;
    text-align: center;

    /deep/ {
      .el-pagination.is-background .el-pager li,
      .el-pagination.is-background button[type="button"]:not(:disabled) {
        background-color: #fff;
        box-shadow: 0px 1px 2px #cacaca;
      }

      .el-pagination.is-background .el-pager li:not(.disabled).active {
        background-color: #246ab6;
        color: #fff;
      }

      @media only screen and (max-width: $--breakpoint-mobile) {
        .el-pagination.is-background .el-pager li {
          min-width: 25px;
        }
        .el-pagination.is-background .el-pager li.more {
          display: none;
        }
      }
    }
  }
}

/deep/ .el-loading-mask {
  position: fixed;
  z-index: 2000;
  background-color: rgba(0, 0, 0, 0.4);

  .path {
    stroke-width: 3;
    stroke: #fff;
  }
}
</style>

