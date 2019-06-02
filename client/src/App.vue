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
html {
  background: $--color-light-1;
}

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: $--color-black;
  display: flex;
  flex-direction: column;
  
}

.page-container {
  max-width: $--width-container;
  margin: 0 auto;
}
</style>
