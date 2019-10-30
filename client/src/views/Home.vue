<template>
  <el-container class="home" v-loading="$loader.active && $loader.type === 'getBooks'">
    <div class="home__container">
      <div class="books">
        <BookPreview
          v-for="(book, index) in booksPreview"
          :key="index"
          :book="book"
          @trigger-show-book="showBookDetails"
        />
        <template v-if="$loader.active && $loader.type === 'getBooks'">
          <!-- (index+1)**20: To not duplicate keys of components -->
          <BookPreviewSkeleton v-for="index in limitBooks" :key="(index+1)**20" />
        </template>
      </div>
      <InfiniteLoading @infinite="getBooks">
        <div slot="spinner"></div>
        <div slot="no-more"></div>
      </InfiniteLoading>
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/common/providers/EventBus";
import InfiniteLoading from "vue-infinite-loading";
import { BookPreview, BookPreviewSkeleton } from "@/components";
import { parseListBooks } from "@/common/helpers/Books";

export default Vue.extend({
  name: "home",
  components: {
    BookPreview,
    BookPreviewSkeleton,
    InfiniteLoading
  },
  data: () => ({
    booksPreview: [] as object[],
    pagination: {
      total: 0 as number,
      currentPage: 0 as number
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
    this.listenEventFilter();
  },
  methods: {
    scrollToTop(): void {
      this.appElement.scrollTo({ top: 0, behavior: "smooth" });
    },
    async getBooks($infinityEvt): Promise<void> {
      this.$loader.active = true;
      this.$loader.type = "getBooks";

      const {
        getUrlBooks,
        $get,
        pagination: { currentPage }
      } = this;

      const response = await $get(getUrlBooks(currentPage));

      const { totalCount, entity } = response;

      this.booksPreview = [
        ...this.booksPreview,
        ...parseListBooks(entity)
      ];
      this.pagination.total = totalCount;
      this.pagination.currentPage += 1;

      if($infinityEvt) {
        if(this.booksPreview.length !== this.pagination.total) {
          $infinityEvt.loaded();
        } else {
          $infinityEvt.complete();
        }
      }

      this.$loader.active = false;
    },
    getUrlBooks(currentPage: number): string {
      const { limitBooks, getParamFilters } = this;

      const url = `/getbooks?limit=${limitBooks}&page=${currentPage}`;

      return getParamFilters(url);
    },
    getParamFilters(url): string {
      const { categoriesSelected } = this.$store.state;

      if (!categoriesSelected || categoriesSelected.length === 0) {
        return url;
      }

      let categoriesIds = "";
      
      categoriesSelected.forEach(
        (category: any) => {
          categoriesIds += `&categoryIds=${category.id}`;
        }
      );
      
      return `${url}${categoriesIds}`;
    },
    showBookDetails(id: number): void {
      const book = this.booksPreview.find(element => element.id === id);
      this.$store.commit("SHOW_BOOK_DETAILS", { book });
    },
    listenEventFilter(): void {
      EventBus.$on("filter-books-by-categories", categoriesSelected => {
        this.resetValues();
        this.getBooks();
      });
    },
    resetValues(): void {
      this.booksPreview = [];
      this.pagination.currentPage = 0;
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
    width: 100%;
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    grid-gap: 20px;
    justify-items: center;
    position: relative;

    /deep/ .el-card {
      height: 100%;
    }
    
    .book {
      &:only-child {
        max-width: 500px;
      }
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
  bottom: auto;
  top: 100px;

  .path {
    stroke-width: 4;
    stroke: $--color-primary;
  }
}
</style>

