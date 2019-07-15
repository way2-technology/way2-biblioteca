<template>
  <el-container id="app">
    <div class="app__header">
      <Header />
    </div>
    <div class="app__content">
      <router-view />
    </div>
    <div class="app__global-components">
      <BookDetails />
      <ModalNewBook />
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import Header from "@/components/Header/Header.vue";
import BookDetails from "@/components/Book/BookDetails.vue";
import ModalNewBook from "@/components/ModalNewBook/ModalNewBook.vue";

export default Vue.extend({
  name: "app",
  components: {
    Header,
    BookDetails,
    ModalNewBook
  }
});
</script>

<style lang="scss">
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

html {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  background: $--color-light-1;
  color: $--color-black;
}

body {
  overflow: hidden;
}

#app {
  display: flex;
  flex-direction: column;
  overflow: auto;
  height: 100vh;
}

.app__header {
  width: 100%;
  position: sticky;
  top: 0;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.15);
  z-index: 9;
}

.page-container {
  max-width: $--width-container;
  margin: 0 auto;
}
</style>
