<template>
  <el-header class="header">
    <div class="header__container" :class="{ 'header__search-focused': inputSearch.isFocused }">
      <div class="header__logo">
        <router-link to="/">
          <img class="img" src="@/assets/img/way2logo.png" alt>
        </router-link>
      </div>
      <div class="header__search">
        <el-input
          class="header__search-input"
          placeholder="Digite para buscar algum livro..."
          suffix-icon="el-icon-search"
          @focus="setSearchFocus(true)"
          @blur="setSearchFocus(false)"
        ></el-input>
        <div class="header__search-sugestions"></div>
      </div>
      <div class="header__notifications">
        <el-button icon="el-icon-bell" type="text" circle></el-button>
      </div>
      <div class="header__user">
        <div class="content">
          <figure class="avatar"></figure>
          <span class="info">
            <span class="name">Robson Braga de Queiroz</span>
            <small class="role">Desenvolvedor</small>
          </span>
        </div>
      </div>
      <div class="header__overlay"></div>
    </div>
  </el-header>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      inputSearch: {
        value: "",
        isFocused: false
      }
    };
  },
  methods: {
    setSearchFocus(value: boolean) {
      this.inputSearch.isFocused = value;
    }
  }
});
</script>


<style lang="scss" scoped>
.header {
  padding: 0.55rem 1rem;
  background: #fff;
  border-bottom: 1px solid rgba(0, 40, 100, 0.12);
  box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);

  &__overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.2);
    opacity: 0;
    visibility: hidden;
    transition: 0.2s;
    z-index: 1;
  }

  &__container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    max-width: $--width-container;
    margin: 0 auto;
  }

  &__search {
    flex-grow: 1;
    padding: 0 1.2rem;
    transition: 0.2s;
    position: relative;

    /deep/ input[type="text"] {
      background: #f9f9fe;
      border: 1px solid rgba(0, 40, 100, 0.12);
      transition: 0.2s;

      &:hover {
        box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
      }
    }

    &-sugestions {
      position: absolute;
      width: calc(100% - 40px);
      height: 200px;
      top: calc(100% + 5px);
      background: #fff;
      border-radius: 3px;
      left: 19px;
      border: 1px solid #dbe0eb;
      transform: translateY(-20px);
      transition: 0.3s;
      opacity: 0;
      visibility: hidden;
    }
  }

  &__search-focused {
    .header__overlay {
      opacity: 1;
      visibility: visible;
    }
    .header__search {
      z-index: 2;

      &-sugestions {
        opacity: 1;
        visibility: visible;
        transform: none;
      }
    }
  }

  &__logo {
    max-width: 100px;

    img {
      width: 100%;
    }
  }

  &__title {
    margin: 0;
  }

  &__notifications {
    button {
      padding: 0;
      color: $--color-black;
    }
    /deep/ i {
      font-size: 20px;
    }
  }

  &__user {
    padding-left: 1rem;

    .content {
      display: flex;
      align-items: center;
      text-align: left;
    }

    .avatar {
      width: 35px;
      height: 35px;
      border-radius: 100%;
      background: #eee;
      margin: 0 10px 0 0;
    }

    .info {
      display: flex;
      flex-direction: column;

      .name {
        font-size: 15px;
        font-weight: bold;
        max-width: 108px;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
      }

      .role {
        color: #9aa0ac;
        font-size: 12px;
      }
    }
  }
}
</style>
