<template>
  <el-link class="book" @click="alertV">
    <el-card>
      <figure class="book__image">
        <img src="https://way2library.azurewebsites.net/images/books/41.jpg">
      </figure>

      <h2>Book 1</h2>

      <el-rate
        v-model="value"
        disabled
        text-color="#ff9900">
      </el-rate>
    </el-card>
  </el-link>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "book",
  data() {
    return {
      value: 4.1
    };
  },
  methods: {
    alertV(): void {
      alert('click')
    }
  }
});
</script>

<style lang="scss">
.book {
  cursor: pointer;

  .el-card {
    box-shadow: none !important;
    transition: 0.2s;

    &:hover {
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1) !important;
    }
  }



  .el-card__body {
    display: flex;
    align-items: center;
    flex-direction: column;
    padding: 8px;
  }

  &__image {
    border: 1px solid #eee;
    border-radius: 4px;
    position: relative;
    overflow: hidden;
    min-width: 160px;
    width: 160px;
    height: 245px;

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

