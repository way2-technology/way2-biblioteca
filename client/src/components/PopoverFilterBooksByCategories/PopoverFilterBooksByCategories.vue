<template>
  <div id="filter-books" class="filter-books">
    <div class="filter-books__wrapper">
      <div class="filter-books__header">
        <h3>Filtrar Livros</h3>
        <el-button :disabled="categoriesSelected.length === 0" @click="clearAllFilters">Limpar</el-button>
      </div>
      <div
        class="filter-books__list"
        v-loading="$loader.active && $loader.type === 'gettingCategories'"
      >
        <el-checkbox-group v-model="categoriesSelected" @change="handleChangeSelected">
          <el-checkbox
            v-for="(item, index) in categoriesOptions"
            :label="item"
            :key="index"
          >{{ item.name }}</el-checkbox>
        </el-checkbox-group>
      </div>
    </div>
    <div class="overlay" @click="closePopover()"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/common/providers/EventBus";

export default Vue.extend({
  name: "popover-filter-books-by-categories",
  data() {
    const { categoriesSelected } = this["$store"].state;

    return {
      categoriesSelected
    };
  },
  computed: {
    categoriesOptions(): object[] {
      return this["$store"].state.categoriesOptions;
    }
  },
  created() {
    this.getAllCategories();
    this.$forceUpdate();
  },
  methods: {
    async getAllCategories(): Promise<void> {
      const {
        $getWithLoader,
        $store,
        $store: {
          state: { categoriesOptions }
        }
      } = this;

      if (categoriesOptions.length === 0) {
        const response = await $getWithLoader({
          url: "/listallcategories",
          typeLoader: "gettingCategories"
        });
        $store.commit("SET_OPTIONS", { categories: response });
      }
    },
    handleChangeSelected(categories): void {
      const { $store, emitEventFilterBooks } = this;

      $store.commit("SET_FILTERS", { categories });
      emitEventFilterBooks();
    },
    clearAllFilters(): void {
      const { $store, emitEventFilterBooks } = this;

      this.categoriesSelected = [];

      $store.commit("SET_FILTERS", { categories: [] });
      emitEventFilterBooks();
    },
    closePopover(): void {
      this.$emit("close");
    },
    emitEventFilterBooks(): void {
      EventBus.$emit("filter-books-by-categories", this.categoriesSelected);
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
  top: calc(100% + 9px);
  right: 0;
  z-index: 1;

  @media screen and (max-width: $--width-size-mobile) {
    top: 70px;
    right: 16px;
    position: fixed;
    width: calc(100% - 33px);
  }

  &__wrapper {
    width: 100%;
    position: relative;
    z-index: 2;
  }

  &__header {
    background: $--color-light-2;
    border-bottom: 1px solid #ddd;
    line-height: 20px;
    padding: 12px 10px;
    border-radius: 4px 4px 0 0;
    display: flex;
    justify-content: space-between;
    align-items: center;

    > div {
      display: flex;
      align-items: center;
    }
    /deep/ {
      button {
        display: flex;
        padding: 2px 5px;
      }
    }
  }

  &__list {
    > div {
      max-height: 400px;
      min-height: 200px;
      overflow: auto;
      position: relative;
      border-radius: 0 0 4px 4px;
      display: flex;
      flex-direction: column;

      @media screen and (max-width: $--width-size-mobile) {
        max-height: calc(100vh - 145px);
      }
    }

    label {
      width: 100%;
      border-bottom: 1px solid #ddd;
      background: #fff;
      color: inherit;
      cursor: pointer;
      display: block;
      padding: 8px 8px 8px 16px;

      &:hover {
        background: $--color-light-1 !important;
      }

      &:last-child {
        border-bottom: 0;
        border-radius: 0 0 4px 4px;
      }

      input[type="checkbox"] {
        margin-right: 10px;
      }
    }
  }

  .overlay {
    background: transparent;
    z-index: 1;

    @media screen and (max-width: $--width-size-mobile) {
      background: rgba(0, 0, 0, 0.4);
    }
  }
}
</style>


