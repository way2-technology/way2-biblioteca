<template>
  <el-container id="app">
    <div class="app__header">
      <Header/>
    </div>
    <div class="app__content">
      <router-view/>
    </div>
    <div class="app__footer"></div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";
import Header from "@/layouts/Header.vue";

export default Vue.extend({
  name: "app",
  components: {
    Header
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
  background: $--color-light-1;
}

body {
  overflow: hidden;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: $--color-black;
  display: flex;
  flex-direction: column;
  overflow: auto;
  height: 100vh;
}

.app__header {
  width: 100%;
  position: sticky;
  top: 0;
  box-shadow: 0 1px 2px rgba(0,0,0,0.15);
  z-index: 9;
}

.page-container {
  max-width: $--width-container;
  margin: 0 auto;
}
</style>
