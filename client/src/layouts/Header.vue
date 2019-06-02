<template>
  <el-header class="header">
    <div class="header__container" :class="{ 'header__search-focused': inputSearch.isFocused }">
      <div class="header__logo">
        <router-link to="/">
          <Way2Logo/>
        </router-link>
      </div>
      <div class="header__search">
        <el-input
          class="header__search-input"
          placeholder="Digite para buscar algum livro..."
          suffix-icon="el-icon-search"
          @focus="setSearchFocus(true)"
        ></el-input>
        <div class="header__search-sugestions"></div>
      </div>
      <!-- <div class="header__notifications">
        <el-tooltip effect="dark" content="Notificações" placement="bottom-end">
          <el-button icon="el-icon-bell" type="text" circle></el-button>
        </el-tooltip>
      </div>-->
      <div class="header__user">
        <template v-if="!userLoggedIn">
          <div class="content user">
            <figure class="avatar"></figure>
            <span class="info">
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
import Way2Logo from "@/assets/img/Way2LogoSvg";

export default Vue.extend({
  components: {
    Way2Logo
  },
  data() {
    return {
      inputSearch: {
        value: "",
        isFocused: false
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
      this.inputSearch.isFocused = value;
    }
  }
});
</script>


<style lang="scss" scoped>
.header {
  padding: 0.55rem 1rem;
  background: $--color-black;
  border-bottom: 1px solid rgba(0, 40, 100, 0.12);
  box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
  display: flex;
  align-items: center;
}
.header__overlay {
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

.header__container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: $--width-container;
  margin: 0 auto;
  width: 100%;
}

.header__logo {
  max-width: 90px;
  padding-top: 7px;

  /deep/ svg {
    width: 100%;
    height: 100%;
    path {
      fill: #fff;
    }
  }
}

.header__search {
  flex-grow: 1;
  padding: 0 1.2rem;
  transition: 0.2s;
  position: relative;

  /deep/ input[type="text"] {
    background: $--color-black-3;
    border-color: transparent;
    border-radius: 3px;
    transition: 0.2s;

    &:hover {
      box-shadow: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
    }
  }

  &-sugestions {
    position: absolute;
    width: calc(100% - 40.5px);
    height: 100px;
    top: 100%;
    background: #fff;
    border-radius: 3px;
    border: 1px solid $--color-grey-2;
    transition: 0.1s;
    opacity: 0;
    visibility: hidden;
  }
}

.header__search-focused {
  .header__overlay {
    opacity: 1;
    visibility: visible;
  }
  .header__search {
    z-index: 2;

    /deep/ input[type="text"] {
      background: #fff;
      border-radius: 3px 3px 0 0;
      border-bottom-color: transparent;
      
    }

    &-sugestions {
      border-left-color: transparent;
      border-right-color: transparent;
      border-bottom-color: transparent;
      border-radius: 0 0 3px 3px;
      opacity: 1;
      visibility: visible;
    }
  }
}

.header__title {
  margin: 0;
}

.header__notifications {
  button {
    padding: 0;
    color: $--color-black-2;
  }
  /deep/ i {
    font-size: 20px;
  }
}

.header__user {
  
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
      max-width: 165px;
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

    /deep/ span {
      display: flex;
      align-items: center;
    }
  }

  .btn-add {
    margin-right: 1rem;
    background-color: $--color-primary;
    background-image: linear-gradient(-180deg, $--color-primary-light-3, $--color-primary-light-2 90%);
    border: 1px solid rgba(27, 31, 35, 0.2);
    color: #fff;
    font-size: 14px;

    &:hover {
      background-image: linear-gradient(-180deg, $--color-primary, $--color-primary-light-1 90%);
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
</style>
