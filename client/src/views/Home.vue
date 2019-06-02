<template>
  <el-container class="home">
    <div class="home__subheader">
      <div class="page-container">
        <div class="buttons">
          <el-button class="btn btn-add" type="text">
            <unicon name="filter"></unicon>
            <strong>Filtrar</strong>
          </el-button>
          <el-button class="btn btn-add" type="text">
            <unicon name="plus"></unicon>
            <strong>Novo</strong>
          </el-button>
        </div>
      </div>
    </div>
    <div class="home__container">
      <!-- <div class="home__books-filters">
        <BooksFilters />
      </div> -->
      <div class="home__books">
        <template v-for="(book, index) in 5">
          <Book :key="index" />
        </template>
      </div> 
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import BooksFilters from "@/components/Books/BooksFilters.vue";
import Book from "@/components/Books/Book.vue";

export default Vue.extend({
  name: "home",
  components: {
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

.home__subheader {
  background: $--color-black;
  border-top: 1px solid $--color-black-3;
  position: sticky;
  top: 0;
  z-index: 1;

  > div {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 5px 16px;
  }

  h1,
  button {
    margin: 0;
    padding: 0;
  }

  .page-title {
    font-size: 14px;
  }

  .buttons {
    width: 100%;
    display: flex;
    justify-content: flex-end;
  }

  .btn {
    padding: 5px;
    margin-left: 8px;
    color: #fff;
    border-radius: 2px;

    &:last-child {
      margin-right: -16px;
    }

    /deep/ span {
      display: flex;
      align-items: center;
      text-transform: uppercase;
      font-size: 10px;
      letter-spacing: 1px;
    }

    svg {
      fill: #fff;
      width: 14px;
      height: 100%;
      margin-right: 3px;
    }

    &:hover {
      span,
      svg {
        color: $--color-primary-light-3;
        fill: $--color-primary-light-3;
      }
    }
  }
}

.home__container {
  padding: 16px;
  display: flex;
}

.home__books {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-gap: 15px;
  margin: 0 auto;

  @media(max-width: 767px) {
    grid-template-columns: 1fr 1fr;
  }
  @media(max-width: 479px) {
    grid-template-columns: 1fr;
  }
}
</style>

