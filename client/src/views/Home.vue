<template>
  <el-container class="home">
    <SubHeader />
    <div class="home__container">
      <!-- <div class="home__books-filters">
        <BooksFilters />
      </div> -->
      <div class="home__books">
        <template v-for="(book, index) in 13">
          <Book :key="index" />
        </template>
      </div> 
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import SubHeader from "@/layouts/SubHeader.vue";
import BooksFilters from "@/components/Books/BooksFilters.vue";
import Book from "@/components/Books/Book.vue";

export default Vue.extend({
  name: "home",
  components: {
    SubHeader,
    BooksFilters,
    Book
  },
  data() {
    return {
      books: []
    };
  },
  async mounted(){
    // await fetch("https://www.booknomads.com/api/v0/isbn/9789000035526")
    // .then(res => res.json())
    // .then(data => {
    //   console.log(`data`, data)
    // });
  }
});
</script>

<style lang="scss" scoped>
.home {
  display: initial;

  &__container {
    margin: 0 auto;
    width: 100%;
    max-width: $--width-container;
  }

  .page-header {
    text-align: left;
    display: flex;
    align-items: center;
  }
}

.home__container {
  padding: 16px;
  display: flex;
}

.home__books {
  width: 100%;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  grid-gap: 20px;
}
</style>

