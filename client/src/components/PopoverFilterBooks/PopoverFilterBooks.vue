<template>
  <div id="filter-books" class="popover-filter-books" v-if="visible">
    <div class="popover-filter-books__header">
      <h3>Filtrar Livros</h3>
      <el-button type="text" icon="el-icon-close">Limpar</el-button>
    </div>
    <div class="popover-filter-books__list">
      <label class="filter-item" v-for="(item, index) in 10" :key="index">
        <el-checkbox>Option</el-checkbox>
      </label>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "popover-filter-books",
  props: {
    visible: {
      type: Boolean,
      default: false
    }
  },
  model: {
    prop: "visible",
    event: "change"
  },
  data() {
    return {
      categories: [] as object[]
    };
  },
  beforeMount() {
    document.addEventListener("click", e => {
      this.targetIsInsideElement(e);
    }, true);
  },
  beforeDestroy() {
    document.removeEventListener("click", e => {
      this.targetIsInsideElement(e);
    }, true);
  },
  computed: {
    popoverElement(): HTMLElement | any {
      return document.querySelector("#filter-books");
    }
  },
  methods: {
    toggleEventListenerClosePopover(type: string = "add"): void {
      const $eventFunction =
        type === "add"
          ? document.addEventListener
          : document.removeEventListener;
    },
    targetIsInsideElement(e) {
      const { target } = e;
      console.log(target);
      console.log(this.popoverElement);
      if (target) {
        if (target === this.popoverElement) {
          return true;
        }
      }
      return false;
    },
    closePopover(e) {
      // if (!this.targetIsInsideElement(e)) {
      //   this.element.style.display = "none";
      //   this._isOpen = false;
      //   this.killOutSideClick();
      // }
    }
  }
});
</script>

<style lang="scss" scoped>
.popover-filter-books {
  background-clip: padding-box;
  background-color: #fff;
  border: 1px solid rgba(27, 31, 35, 0.15);
  border-radius: 3px;
  box-shadow: 0 3px 12px rgba(27, 31, 35, 0.15);
  font-size: 12px;
  margin-bottom: 20px;
  margin-top: 4px;
  position: relative;
  width: 300px;
  position: absolute;
  top: calc(100% + 6px);
  right: 0;

  &:before {
    content: "";
    position: absolute;
    border-color: transparent;
    border-style: solid;
    top: -12px;
    right: 10px;
    border-top-width: 0;
    border-width: 6px;
    border-bottom-color: #f6f8fa;
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

    .filter-item {
      border-bottom: 1px solid #eaecef;
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
}
</style>


