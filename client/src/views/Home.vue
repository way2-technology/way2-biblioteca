<template>
  <el-container class="home">
    <div class="home__container">
      <div class="page-header">
        <h1 class="page-title">Dashboard</h1>
         <el-button type="text" circle>
           <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="inherit"><path d="M19,2H5A3,3,0,0,0,2,5V6.17a3,3,0,0,0,.25,1.2l0,.06a2.81,2.81,0,0,0,.59.86L9,14.41V21a1,1,0,0,0,.47.85A1,1,0,0,0,10,22a1,1,0,0,0,.45-.11l4-2A1,1,0,0,0,15,19V14.41l6.12-6.12a2.81,2.81,0,0,0,.59-.86l0-.06A3,3,0,0,0,22,6.17V5A3,3,0,0,0,19,2ZM13.29,13.29A1,1,0,0,0,13,14v4.38l-2,1V14a1,1,0,0,0-.29-.71L5.41,8H18.59ZM20,6H4V5A1,1,0,0,1,5,4H19a1,1,0,0,1,1,1Z"></path></svg>
         </el-button>
      </div>
      <!-- <el-card>
        <div slot="header" class="clearfix">
          <h1 class="el-card__title">Livros</h1>
        </div>
        <div v-for="o in 4" :key="o" class="text item">{{'List item ' + o }}</div>
      </el-card> -->
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
  &__container {
    margin: 0 auto;
    width: 100%;
    max-width: $--width-container;
  }

  .page-header {
    text-align: left;
    display: flex;
    align-items: center;
    justify-content: space-between;
  }

  /* .el-card {
    &__title {
      margin: 0;
      font-size: 1.5rem;
    }
    &__header {
      > div {
        display: flex;
        justify-content: space-between;
        align-items: center;
      }

      button {
        padding: 0;
      }
    }
  } */
}
</style>

