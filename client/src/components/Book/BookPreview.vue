<template>
  <el-link class="book">
    <el-card>
      <figure class="book__image" @click="triggerShowBook">
        <img :src="image" />
      </figure>

      <div class="book__categories">
        <el-tag size="mini">{{category}}</el-tag>
      </div>

      <h2 class="book__title">{{ title }}</h2>

      <footer>
        <el-rate disabled v-model="rate.value" :colors="rate.colors" />

        <template v-if="$userLogged">
          <el-tooltip
            class="item"
            effect="dark"
            content="Pegar este livro emprestado"
            placement="top"
          >
            <button type="text" v-loading>
              <Unicon name="bookmark" />
            </button>
          </el-tooltip>
        </template>
      </footer>
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
    padding: 0;
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
    margin: 15px 0;

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
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }

  .book__title {
    padding: 15px;
    font-size: 20px;
    line-height: 22px;
    flex-grow: 1;
    display: flex;
    align-items: center;
    text-align: center;
  }

  footer {
    display: flex;
    align-items: center;
    justify-content: space-around;
    width: 100%;
    border-top: 1px solid #eee;
    padding: 8px 16px;

    button {
      background: transparent;
      border: 0;
      cursor: pointer;
    }
  }
}
</style>

