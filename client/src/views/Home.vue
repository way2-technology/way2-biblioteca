<template>
  <el-container class="home">
    <div class="home__subheader">
      <div class="page-container">
        <div class="buttons">
          <el-button class="btn btn-filter" type="text">
            <unicon name="filter"></unicon>
            <span>Filtros</span>
          </el-button>
        </div>
      </div>
    </div>
    <div class="home__container">
      
    </div>
  </el-container>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "home",
  components: {}
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
  background: $dark-2;
  border-bottom: 1px solid $border-grey-2;
  position: sticky;
  top: 0;

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

  .btn-filter {
    margin-left: 8px;
    color: #fff;

    /deep/ span {
      display: flex;
      align-items: center;
      text-transform: uppercase;
      font-size: 12px;
      font-weight: 600;
    }

    svg {
      fill: #fff;
      width: 14px;
      margin-right: 5px;
    }
  }
  
}
</style>

