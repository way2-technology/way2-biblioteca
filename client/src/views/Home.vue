<template>
  <el-container class="home">
    <div class="home__container">
      <div class="books" v-loading="$loader.active && $loader.type === 'booksPreview'">
        <template v-for="(book, index) in booksPreview">
          <BookPreview :book="book" :key="index" @trigger-show-book="showBookDetails" />
        </template>
      </div>
      <div class="books-pagination" v-if="booksPreview.length > 0">
        <el-pagination
          background
          layout="prev, pager, next"
          :pager-count="5"
          :total="totalBooks"
          @current-change="getBooks"
        ></el-pagination>
      </div>
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/common/providers/EventBus";
import { BookPreview } from "@/components";
import { parseListBooks } from "@/common/helpers/Books";

export default Vue.extend({
  name: "home",
  components: {
    BookPreview
  },
  data: () => ({
    rawListBooks: [] as object[],
    booksPreview: [] as object[],
    totalBooks: 0 as number
  }),
  computed: {
    appElement(): HTMLDivElement | any {
      return document.querySelector("#app");
    }
  },
  created() {
    this.getBooks();
  },
  methods: {
    async getBooks(evtPage: number = 0): Promise<void> {
      this.scrollToTop();

      evtPage = evtPage <= 0 ? 0 : evtPage - 1;

      const response = await this.$getWithLoader({
        url: `/getbooks?limit=12&page=${evtPage}`,
        typeLoader: "booksPreview"
      });

      const { 
        total, 
        currentPage, 
        entity 
      } = response;

      this.rawListBooks = entity;
      this.booksPreview = parseListBooks(entity);
      this.totalBooks = total;
    },
    showBookDetails(id: string): void {
      const book = this.rawListBooks.find((element: any) => element.id === id);

      this.$store.commit("SHOW_BOOK_DETAILS", { book });
    },
    scrollToTop(): void {
      this.appElement.scrollTo({ top: 0, behavior: "smooth" });
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

    /deep/ .el-loading-mask {
      z-index: 2;
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

      @media only screen and (max-width: 767px) {
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
</style>

