<template>
  <el-header class="header">
    <div class="header__container">
      <div class="header__logo">
        <router-link to="/">
          <Way2Logo />
        </router-link>
      </div>
      <HeaderSearch />
      <HeaderInfo />
    </div>
  </el-header>
</template>

<script lang="ts">
import Vue from "vue";
import Way2Logo from "@/assets/img/Way2LogoSvg.vue";
import HeaderSearch from "./HeaderSearch.vue";
import HeaderInfo from "./HeaderInfo.vue";

export default Vue.extend({
  name: "header-index",
  components: {
    Way2Logo,
    HeaderSearch,
    HeaderInfo
  }
});
</script>


<style lang="scss">
.header {
  padding: 0.55rem 1rem;
  background: $--color-black;
  border-bottom: 1px solid rgba(0, 40, 100, 0.12);
  box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
  display: flex;
  align-items: center;

  &__container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    max-width: $--width-container;
    margin: 0 auto;
    width: 100%;
  }

  &__logo {
    max-width: 75px;
    padding-top: 7px;

    svg {
      width: 100%;
      height: 100%;
      path {
        fill: #fff;
      }
    }
  }
}
</style>
