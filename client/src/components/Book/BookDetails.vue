<template>
  <transition name="translate-aside">
    <aside class="book-details" v-if="value" :class="{'book-details--open': value}">
      <div class="book-details__wrapper">
        <el-header>
          <h2 class="title">{{ bookDisplay.title }}</h2>
          <el-button
            class="close"
            size="mini"
            icon="el-icon-close"
            circle
            @click="closeBookDetails"
          ></el-button>
        </el-header>
        <el-row class="book-details__content">
          <el-col>
            <figure class="image">
              <img :src="bookDisplay.image" alt>
            </figure>

            <div class="rate">
              <el-rate disabled v-model="rate.value" :colors="rate.colors"/>
              <span class="count">5 Reviews</span>
            </div>
          </el-col>
          <el-col>
            <div class="description">{{bookDisplay.description}}</div>
          </el-col>
        </el-row>
        <el-row class="comments"></el-row>
      </div>
      <div class="book-details__overlay" @click="closeBookDetails"></div>
    </aside>
  </transition>
</template>

<script lang="ts">
import Vue from "vue";
import BookRate from "./BookRate.mixin";

export default Vue.extend({
  props: {
    value: {
      type: Boolean,
      default: true
    },
    book: {
      type: Object
    }
  },
  mixins: [BookRate],
  data() {
    return {};
  },
  computed: {
    bookDisplay(): object {
      const {
        id,
        volumeInfo: {
          title: bookTitle,
          description: bookDesc,
          categories: bookCats,
          imageLinks: { thumbnail }
        }
      } = this.book;

      return {
        id,
        title: bookTitle ? bookTitle : "",
        description: bookDesc ? bookDesc : "",
        category: bookCats && typeof bookCats === "object" ? bookCats[0] : "",
        image: thumbnail ? thumbnail : ""
      };
    }
  },
  methods: {
    closeBookDetails(): void {
      this.$emit("input", false);
    }
  }
});
</script>


<style lang="scss">
.book-details {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 99;

  &__wrapper {
    position: absolute;
    top: 0;
    right: 0;
    width: 70%;
    height: 100%;
    background: #fff;
    display: flex;
    flex-direction: column;
    box-shadow: -2px 0 8px rgba(0, 0, 0, 0.15);
    z-index: 1;
  }

  .el-header {
    position: relative;
    display: flex;
    align-items: center;
    border-bottom: 1px solid #e8e8e8;

    h2 {
      font-size: 22px;
    }

    .close {
      position: absolute;
      right: 10px;
      top: 50%;
      transform: translateY(-50%);
    }
  }

  &__content {
    display: flex;
    flex-grow: 1;
    padding: 20px;

    .el-col {
      width: auto;
    }

    .image {
      border: 1px solid #ddd;
      border-radius: 4px;
      position: relative;
      overflow: hidden;
      width: 190px;
      height: 300px;

      img {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 100%;
        height: 100%;
      }
    }

    .rate {
      margin: 15px 0;
    }

    .description {
      padding-left: 30px;
      text-align: left;
    }
  }

  &__overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
  }
}

.translate-aside-enter-active {
  transition: all 0.2s ease;
}
.translate-aside-leave-active {
  transition: all 0.1s cubic-bezier(1, 0.5, 0.8, 1);
}
.translate-aside-enter,
.translate-aside-leave-to {
  transform: translateX(5px);
  opacity: 0;
}
</style>
