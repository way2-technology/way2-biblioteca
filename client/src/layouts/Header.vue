<template>
  <el-header
    class="header"
    :class="{
      'header--search-focused': search.isFocused,
      'header--search-mobile-open': search.openOnMobile
    }"
  >
    <div class="header__container">
      <div class="header__logo">
        <router-link to="/">
          <Way2Logo/>
        </router-link>
      </div>
      <div class="header__search">
        <el-input
          class="input"
          placeholder="Digite para buscar algum livro..."
          suffix-icon="el-icon-search"
          v-model="search.value"
          @focus="setSearchFocus(true)"
        ></el-input>
        <el-button
          class="toggle-mobile"
          type="text"
          icon="el-icon-search"
          @click="toggleSearchMobile"
        ></el-button>
      </div>
      <div class="header__actions">
        <el-tooltip effect="dark" content="Filtrar Livros" placement="bottom">
          <button type="button">
            <unicon name="filter"></unicon>
          </button>
        </el-tooltip>
        <el-tooltip effect="dark" content="Novo Livro" placement="bottom">
          <button type="button">
            <unicon name="plus-circle"></unicon>
          </button>
        </el-tooltip>
      </div>
      <div class="header__user">
        <template v-if="!userLoggedIn">
          <div class="content user">
            <figure class="avatar"></figure>
            <span class="info no-mobile">
              <span class="name">Robson Braga de Queiroz</span>
              <small class="role">Desenvolvedor</small>
            </span>
          </div>
        </template>
        <template v-else>
          <div class="content login">
            <el-button plain class="btn btn-login">
              <unicon name="entry"></unicon>Login
            </el-button>
          </div>
        </template>
      </div>
      <div class="header__overlay" @click="setSearchFocus(false)"></div>
    </div>
  </el-header>
</template>

<script lang="ts">
import Vue from "vue";
import Store from "../store/store";
import Way2Logo from "@/assets/img/Way2LogoSvg.vue";

export default Vue.extend({
  components: {
    Way2Logo
  },
  data() {
    return {
      search: {
        value: "",
        isFocused: false,
        openOnMobile: false
      }
    };
  },
  computed: {
    userLoggedIn(): boolean {
      return false;
    }
  },
  methods: {
    setSearchFocus(value: boolean): void {
      this.search.isFocused = value;
    },
    toggleSearchMobile() {
      this.search.openOnMobile = !this.search.openOnMobile;
    }
  }
});
</script>


<style lang="scss">
.header {
  padding: 0.55rem 1rem;
  background: $--color-black;
  border-bottom: 1px solid rgba(0, 40, 100, 0.12);
  box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
  display: flex;
  align-items: center;

  &__overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.4);
    opacity: 0;
    visibility: hidden;
    transition: 0.2s;
    z-index: 8;
  }

  &__container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    max-width: $--width-container;
    margin: 0 auto;
    width: 100%;
  }

  &__logo {
    max-width: 90px;
    padding-top: 7px;

    svg {
      width: 100%;
      height: 100%;
      path {
        fill: #fff;
      }
    }
  }

  &__search {
    margin-left: 1.2rem;
    position: relative;
    display: flex;
    justify-content: flex-end;
    flex-grow: 1;
    transition: 0.2s;

    input[type="text"] {
      background: $--color-black-3;
      border-color: transparent;
      border-radius: 3px;
      transition: 0.2s;

      &:hover {
        box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
      }
    }

    .toggle-mobile {
      display: none;
      color: #fff;
      font-size: 16px;
    }

    @media only screen and (max-width: 767px) {
      .input {
        display: none;
      }
      .toggle-mobile {
        display: block;
      }
    }
  }

  &__title {
    margin: 0;
  }

  &__notifications {
    button {
      padding: 0;
      color: $--color-black-2;
    }
    i {
      font-size: 20px;
    }
  }

  &__actions {
        display: flex;
    width: 70px;
    justify-content: space-around;
    margin: 0 10px;

    button {
      background: transparent;
      border: 0;
      min-height: 40px;
      display: flex;
      align-items: center;
      justify-content: center;
      flex-grow: 1;
      cursor: pointer;

      svg {
        fill: #fff;
        width: 20px;
      }
    }
  }

  &__user {
    .content {
      display: flex;
      align-items: center;
      text-align: left;
    }

    .avatar {
      width: 30px;
      height: 30px;
      border-radius: 100%;
      background: #eee;
      margin: 0 8px 0 0;
    }

    .info {
      display: flex;
      flex-direction: column;
      color: #fff;

      .name {
        font-size: 15px;
        font-weight: bold;
        max-width: 115px;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
      }

      .role {
        color: #9aa0ac;
        font-size: 12px;
      }
    }

    .btn {
      padding: 5px 12px;
      color: #fff;
      border-radius: 3px;
      height: 40px;

      svg {
        width: 18px;
        height: 18px;
        margin-right: 5px;
        fill: #fff;
      }

      span {
        display: flex;
        align-items: center;
      }
    }

    .btn-add {
      margin-right: 1rem;
      background-color: $--color-primary;
      background-image: linear-gradient(
        -180deg,
        $--color-primary-light-3,
        $--color-primary-light-2 90%
      );
      border: 1px solid rgba(27, 31, 35, 0.2);
      color: #fff;
      font-size: 14px;

      &:hover {
        background-image: linear-gradient(
          -180deg,
          $--color-primary,
          $--color-primary-light-1 90%
        );
        background-position: -0.5em;
        border-color: rgba(27, 31, 35, 0.5);
      }
    }

    .btn-login {
      background: transparent;

      &:hover {
        color: $--color-primary-light-2;
        background: $--color-primary-light-7;
        svg {
          fill: $--color-primary-light-2;
        }
      }
    }
  }
}

.header--search-focused {
  .header__overlay {
    opacity: 1;
    visibility: visible;
  }
  .header__search {
    z-index: 9;

    input[type="text"] {
      background: #fff;
    }
  }
}
</style>
