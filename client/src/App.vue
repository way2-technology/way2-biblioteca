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
  name: "home",
  components: {
    Header
  }
});
</script>


<style lang="scss">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: $--color-black;
  display: flex;
  flex-direction: column;
}
#nav {
  padding: 30px;
  a {
    font-weight: bold;
    color: $--color-black;
    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

body {
  margin: 0;
  padding: 0;
}

.app__content {
  height: calc(100vh - 60px);
  background: #f5f7fb;
  padding: 20px;
}
</style>
