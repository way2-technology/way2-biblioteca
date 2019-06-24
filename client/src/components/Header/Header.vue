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
        <el-autocomplete
          class="input"
          placeholder="Digite para buscar algum livro..."
          suffix-icon="el-icon-search"
          v-model="search.value"
          :fetch-suggestions="getBooksSearch"
          :debounce="500"
          :trigger-on-focus="false"
          @select="selectBookSearched"
          @focus="setSearchFocus(true)"
        >
          <div slot-scope="item">{{item}}</div>
        </el-autocomplete>
        <el-button
          class="toggle-mobile"
          type="text"
          icon="el-icon-search"
          @click="toggleSearchMobile"
        ></el-button>
      </div>
      <template v-if="!userLoggedIn">
        <div class="header__actions">
          <el-tooltip effect="dark" content="Filtrar Livros" placement="bottom">
            <button type="button">
              <el-badge :value="12">
                <unicon name="filter"></unicon>
              </el-badge>
            </button>
          </el-tooltip>
          <el-tooltip effect="dark" content="Novo Livro" placement="bottom">
            <button type="button">
              <unicon name="plus-circle"></unicon>
            </button>
          </el-tooltip>
        </div>
        <div class="header__user">
          <div class="content user">
            <figure class="avatar"></figure>
            <span class="info no-mobile">
              <span class="name">Robson Braga de Queiroz</span>
              <small class="role">Desenvolvedor</small>
            </span>
          </div>
        </div>
      </template>
      <template v-else>
        <div class="header__login">
          <el-button type="plain">
            <unicon name="entry"></unicon>Login
          </el-button>
        </div>
      </template>
      <div class="header__overlay" @click="setSearchFocus(false)"></div>
    </div>
  </el-header>
</template>

<script lang="ts">
import Vue from "vue";
import Way2Logo from "@/assets/img/Way2LogoSvg.vue";

export default Vue.extend({
  components: {
    Way2Logo
  },
  data() {
    return {
      search: {
        value: "" as string,
        isFocused: false as boolean,
        openOnMobile: false as boolean,
        booksResults: [] as object[]
      }
    };
  },
  computed: {
    userLoggedIn(): boolean {
      return false;
    }
  },
  methods: {
    getBooksSearch(queryString, callback): void {
      callback(this.search.booksResults);
    },
    selectBookSearched($book): void {
      alert(JSON.stringify($book));
    },
    setSearchFocus(value: boolean): void {
      this.search.isFocused = value;
    },
    toggleSearchMobile(): void {
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

    > div {
      width: 100%;
    }

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
  }

  &__login {
    button {
      padding: 0 15px;
      height: 40px;
      margin-left: 1.2rem;
      border-radius: 2px;

      span {
        display: flex;
        align-items: center;
      }

      svg {
        width: 18px;
        margin-right: 5px;
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

/* .el-autocomplete-suggestion {
  display: none;
} */
</style>
