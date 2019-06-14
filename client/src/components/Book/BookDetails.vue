<template>
  <aside class="book-details" :class="{'book-details--open': value}">
    <div class="book-details__wrapper">
      <header>
        <h2 class="title">Book Title</h2>
        <el-button class="close" size="mini" icon="el-icon-close" circle></el-button>
      </header>
      <div class="content">
        <div class="">

        </div>
      </div>
    </div>
    <div class="book-details__overlay"></div>
  </aside>
</template>

<script>
export default {
  props: {
    value: {
      type: Boolean,
      default: false
    },
    bookDetails: {
      type: Object
    },
  },
  data() {
    return {
    }
  }
}
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
    width: 60%;
    height: 100%;
    background: #fff;
    display: flex;
    flex-direction: column;
    box-shadow: -2px 0 8px rgba(0, 0, 0, 0.15);
    z-index: 1;

    header,
    .content {
      padding: 20px 16px;
    }

    header {
      border-bottom: 1px solid #e8e8e8;
      text-align: left;
      position: relative;

      h2 {
        font-size: 18px;
      }

      .close {
        position: absolute;
        right: 10px;
        top: 50%;
        transform: translateY(-50%);
      }
    }

    .content {
      flex-grow: 1;
    }
  }
  &__overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
  }
}
</style>
