<template>
  <el-container class="home">
    <SubHeader/>
    <section class="home__container">
      <div class="home__books" v-loading="books.loading">
        <template v-for="(book, index) in books.items">
          <BookPreview
            :title="book.title"
            :category="book.category"
            :image="book.image"
            :key="index"
          />
        </template>
      </div>
      <div class="home__pagination" v-if="books.items.length > 0">
        <el-pagination
          background
          layout="prev, pager, next"
          :pager-count="5"
          :total="books.totalItems"
          @current-change="getBooks"
        ></el-pagination>
      </div>
    </section>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import SubHeader from "@/layouts/SubHeader.vue";
import BookPreview from "@/components/Book/BookPreview.vue";

export default Vue.extend({
  name: "home",
  components: {
    SubHeader,
    BookPreview
  },
  data() {
    return {
      books: {
        items: [],
        totalItems: 0,
        loading: true
      }
    };
  },
  async mounted() {
    this.getBooks();
  },
  methods: {
    async getBooks($evtPage) {
      this.books.loading = true;

      await fetch(
        `https://www.googleapis.com/books/v1/volumes?q=jorge+amado&startIndex=${
          $evtPage ? $evtPage : 0
        }&maxResults=12`
      )
        .then(res => res.json())
        .then(response => {
          const { items, totalItems } = response;
          this.books.totalItems = totalItems;
          this.books.items = this.parseBooks(items);
          this.books.loading = false;
        });
    },
    parseBooks(books) {
      return books.map((book, index) => {
        const title = book.volumeInfo.title;
        const category = book.volumeInfo.categories
          ? book.volumeInfo.categories[0]
          : "General";
        const image = book.volumeInfo.imageLinks
          ? book.volumeInfo.imageLinks.thumbnail
          : "";

        return {
          id: book.id,
          title,
          category,
          image
        };
      });
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
  }

  &__container {
    padding: 16px;
    display: flex;
    flex-direction: column;
  }

  &__books {
    min-height: calc(100vh - 120px);
    width: 100%;
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    grid-gap: 20px;
    position: relative;

    /deep/ .el-loading-mask {
      z-index: 2;
    }
  }

  &__pagination {
    margin: 40px 0;
  }
  /deep/ .el-pagination.is-background .el-pager li,
  /deep/ .el-pagination.is-background button[type="button"]:not(:disabled) {
    background-color: #fff;
  }
}
</style>

