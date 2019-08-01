<template>
  <el-container class="home">
    <div class="home__container">
      <div class="books" v-loading="booksPreview.loading">
        <template v-for="(book, index) in booksPreview.books">
          <BookPreview
            :id="book.id"
            :title="book.title"
            :category="book.category"
            :image="book.image"
            :key="index"
            @trigger-show-book="showBookDetails"
          />
        </template>
      </div>
      <div class="books-pagination" v-if="booksPreview.books.length > 0">
        <el-pagination
          background
          layout="prev, pager, next"
          :pager-count="5"
          :total="booksPreview.totalItems"
          @current-change="getBooks"
        ></el-pagination>
      </div>
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import BookPreview from "@/components/Book/BookPreview.vue";
import EventBus from "@/providers/EventBus.js";

interface IBookPreview {
  books: object[];
  totalItems: number;
  loading: boolean;
}

export default Vue.extend({
  name: "home",
  components: {
    BookPreview
  },
  data: () => ({
    rawApiBooks: [] as object[],
    booksPreview: {
      books: [],
      totalItems: 0,
      loading: false
    } as IBookPreview
  }),
  computed: {
    appElement(): HTMLElement | any {
      return document.querySelector("#app");
    }
  },
  created() {
    this.getBooks();
  },
  methods: {
    async getBooks(evtPage: number = 0): Promise<void> {
      this.booksPreview.loading = true;

      await fetch(
        `https://www.googleapis.com/books/v1/volumes?q=jorge+amado&startIndex=${evtPage}&maxResults=12`
      )
        .then(res => res.json())
        .then(response => {
          const { items, totalItems } = response;
          const { $nextTick, appElement, parsePreviewBooks } = this;

          this.rawApiBooks = items;
          this.booksPreview.books = parsePreviewBooks(items);
          this.booksPreview.totalItems = totalItems;
          this.booksPreview.loading = false;

          $nextTick(() => {
            appElement.scrollTo({ top: 0, behavior: "smooth" });
          });
        })
        .catch(() => {
          this.booksPreview.loading = false;
        });
    },
    parsePreviewBooks(books: object[]): object[] {
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
    showBookDetails(id: string): void {
      const book = this.rawApiBooks.find((element: any) => element.id === id);

      this["$store"].commit("SHOW_BOOK_DETAILS", { book });
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
          min-width: auto;
        }
        .el-pagination.is-background .el-pager li.more {
          display: none;
        }
      }
    }
  }
}
</style>

