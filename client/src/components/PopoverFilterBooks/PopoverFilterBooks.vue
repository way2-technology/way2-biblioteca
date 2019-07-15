<template>
  <div id="filter-books" class="filter-books">
    <div class="filter-books__wrapper">
      <div class="filter-books__header">
        <h3>Filtrar Livros</h3>
        <el-button type="text" icon="el-icon-close">Limpar</el-button>
      </div>
      <div class="filter-books__list">
        <label class="item" v-for="(item, index) in 10" :key="index">
          <el-checkbox>Option</el-checkbox>
        </label>
      </div>
    </div>
    <div class="overlay" @click="closePopover()"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "popover-filter-books",
  model: {
    prop: "visible",
    event: "visible"
  },
  data() {
    return {
      categories: [] as object[]
    };
  },
  methods: {
    closePopover(): void {
      this.$emit("close");
    }
  }
});
</script>

<style lang="scss" scoped>
.filter-books {
  background-clip: padding-box;
  background-color: #fff;
  border: 1px solid rgba(27, 31, 35, 0.15);
  border-radius: 3px;
  box-shadow: 0 3px 12px rgba(27, 31, 35, 0.15);
  font-size: 12px;
  position: relative;
  width: 300px;
  position: absolute;
  top: calc(100% + 10px);
  right: 0;

  &:before {
    content: "";
    position: absolute;
    border-color: transparent;
    border-style: solid;
    top: -15px;
    right: 8px;
    border-top-width: 0;
    border-width: 8px;
    border-bottom-color: #f6f8fa;
    z-index: 2;
  }

  &__wrapper {
    position: relative;
    z-index: 1;
  }

  &__header {
    background: #f6f8fa;
    border-bottom: 1px solid #e1e4e8;
    line-height: 16px;
    padding: 12px 10px;
    border-radius: 4px 4px 0 0;
    display: flex;
    justify-content: space-between;

    /deep/ {
      button {
        padding: 0;
      }
    }
  }

  &__list {
    max-height: 400px;
    overflow: auto;
    position: relative;

    .item {
      border-bottom: 1px solid #eaecef;
      background: #fff;
      color: inherit;
      cursor: pointer;
      display: block;
      overflow: hidden;
      padding: 8px 8px 8px 16px;

      &:last-child {
        border-bottom: 0;
        border-radius: 0 0 4px 4px;
      }

      &:hover:not(.is-checked) {
        background: rgba(36, 106, 182, 0.2);
      }

      input[type="checkbox"] {
        margin-right: 10px;
      }
    }
  }

  .overlay {
    background: transparent;
  }
}
</style>


