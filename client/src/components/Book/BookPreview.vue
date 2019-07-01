<template>
  <el-link class="book" @click="triggerShowBook">
    <el-card>
      <figure class="book__image">
        <img :src="image">
      </figure>

      <div class="book__categories">
        <el-tag size="mini">{{category}}</el-tag>
      </div>

      <h2 class="book__title">{{ title }}</h2>

      <el-rate 
        disabled
        v-model="rate.value" 
        :colors="rate.colors"
      />
    </el-card>
  </el-link>
</template>

<script lang="ts">
import Vue from "vue";
import BookRate from "./BookRate.mixin";

export default Vue.extend({
  name: "book-preview",
  props: {
    id: {
      type: [String, Number],
      required: true
    },
    title: {
      type: String,
      default: ""
    },
    category: {
      type: String,
      default: ""
    },
    image: {
      type: String,
      default: ""
    }
  },
  mixins: [BookRate],
  methods: {
    triggerShowBook(): void {
      this.$emit("trigger-show-book", this.id);
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
    min-height: 100%;
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
    margin: 8px 0;
    font-size: 20px;
    line-height: 22px;
    flex-grow: 1;
    display: flex;
    align-items: center;
    text-align: center;
  }
}
</style>

