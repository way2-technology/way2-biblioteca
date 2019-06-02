<template>
  <el-card class="book">
    <figure class="book__image">
      <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png">
    </figure>
    <div class="book__content">
      <h2>Book 1</h2>
      <div class="desc">
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. At magni doloribus corporis quas laboriosam praesentium. Ullam obcaecati perspiciatis, exercitationem atque excepturi ex blanditiis temporibus nemo, maiores adipisci consequatur. Officiis, debitis.</p>
      </div>
      <div class="stars">
        <el-rate
          v-model="value"
          disabled
          text-color="#ff9900">
        </el-rate>
      </div>
    </div>
  </el-card>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "book",
  data() {
    return {
      value: 5
    };
  },
});
</script>

<style lang="scss">
.book {

  .el-card__body {
    display: flex;
    padding: 10px;
  }

  &__image {
    border: 1px solid #eee;
    border-radius: 5px;
    position: relative;
    overflow: hidden;
    min-width: 160px;
    width: 160px;
    height: 200px;
    flex-basis: 160px;

    img {
      position: absolute;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
      width: 100%;
      height: 100%;
    }
  }
}
</style>

