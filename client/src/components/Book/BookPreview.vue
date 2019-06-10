<template>
  <el-link class="book" @click="alertV">
    <el-card>
      <figure class="book__image">
        <img :src="image">
      </figure>

      <div class="book__categories">
        <el-tag size="mini">{{category}}</el-tag>
      </div>

      <h2 class="book__title">{{ title }}</h2>

      <el-rate v-model="value" disabled text-color="#ff9900"></el-rate>
    </el-card>
  </el-link>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  name: "book-preview",
  props: {
    title: {
      type: String
    },
    category: {
      type: String
    },
    image: {
      type: String
    }
  },
  data() {
    return {
      value: 4.1
    };
  },
  methods: {
    alertV(): void {
      alert("click");
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
    justify-content: center;
    padding: 16px;
    min-height: 410px;
  }

  &__image {
    border: 1px solid #ddd;
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

  .book__categories {
    margin: 15px 0 8px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }

  .book__title {
    margin: 5px 0 10px;
    font-size: 20px;
    line-height: 22px;
  }
}
</style>

