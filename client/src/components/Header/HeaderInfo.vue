<template>
  <div class="header__info">
    <div>
      <div class="actions">
        <button class="action__filters" type="button" @click="popoverVisible = !popoverVisible">
          <el-badge :value="countFilters" :class="{'badge-visible': countFilters > 0}">
            <unicon name="filter"></unicon>
          </el-badge>
        </button>
        <PopoverFilterBooksByCategories v-if="popoverVisible" @close="popoverVisible = false" />
      </div>
      <div class="user" v-if="$userLogged">
        <el-dropdown class="user__dropdown" trigger="click" @command="handleDropdownCommand">
          <button type="button" class="btn-dropdown">
            <figure class="avatar">
              <img :src="$userLogged.avatar" alt="User Avatar" />
            </figure>
            <span class="name no-mobile">{{ $userLogged.firstName }}</span>
            <i class="el-icon-arrow-down el-icon--right"></i>
          </button>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item icon="el-icon-circle-plus-outline" command="add-book">Novo Livro</el-dropdown-item>
            <el-dropdown-item command="see-books">
              <unicon name="notebooks"></unicon>
              <span>Ver Livros emprestados</span>
            </el-dropdown-item>
            <el-dropdown-item command="see-goals">
              <unicon name="books"></unicon>
              <span>Metas de leitura</span>
            </el-dropdown-item>
            <el-dropdown-item command="logout">
              <unicon name="exit"></unicon>
              <span>Sair</span>
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </div>
    </div>
    <div v-if="!$userLogged">
      <div class="login">
        <GoogleLogin :params="googleParams" :onSuccess="handleLogin">
          <unicon name="entry"></unicon>
          <strong>ENTRAR</strong>
        </GoogleLogin>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { PopoverFilterBooksByCategories } from "@/components";
import EventBus from "@/providers/EventBus.js";
import GoogleLogin from "vue-google-login";

export default Vue.extend({
  name: "header-info",
  components: {
    PopoverFilterBooksByCategories,
    GoogleLogin
  },
  data() {
    return {
      popoverVisible: false,
      googleParams: {
        client_id:
          "598656881420-qi31ki4kif89imbuu209qsac7s2j6i0j.apps.googleusercontent.com"
      }
    };
  },
  computed: {
    countFilters(): number {
      const { categoriesSelected } = this["$store"].state;
      return categoriesSelected.length;
    }
  },
  methods: {
    handleLogin(user: any): void {
      this["$store"].commit("USER_LOGIN", { user });
    },
    handleLogout(): void {
      this["$store"].commit("USER_LOGOUT");
    },
    handleDropdownCommand(command: string): void {
      const { emitEventModalNewBook, handleLogout } = this;

      switch (command) {
        case "add-book":
          emitEventModalNewBook();
          break;
        case "logout":
          handleLogout();
      }
    },
    emitEventModalNewBook(): EventBus<void> {
      EventBus.$emit("show-modal-new-book");
    }
  }
});
</script>

<style lang="scss" scoped>
.header__info {
  &,
  > div {
    display: flex;
    align-items: center;
  }

  .actions {
    display: flex;
    width: 50px;
    align-items: center;
    justify-content: center;
    position: relative;
    margin-left: 7px;

    button {
      display: flex;
      align-items: center;
      justify-content: center;
      flex-grow: 1;
      background: transparent;
      border: 0;
      min-height: 40px;
      cursor: pointer;
      outline: none;
      border-radius: 3px;

      &:hover {
        background: #3f4448;
      }

      svg {
        fill: #fff;
        width: 20px;
      }
    }

    .action__filters {
      /deep/ .el-badge__content {
        display: none;
      }

      .badge-visible {
        /deep/ .el-badge__content {
          display: block;
        }
      }
    }
  }

  .user {
    .btn-dropdown {
      display: flex;
      align-items: center;
      text-align: left;
      padding: 5px 8px;
      color: #fff;
      background: transparent;
      border: 0;
      border-radius: 2px;
      cursor: pointer;
      outline: none;
      transition: 0.2s;

      &:hover {
        background: #3f4448;
      }
    }

    .avatar {
      width: 30px;
      height: 30px;
      border-radius: 100%;
      background: #eee;
      margin: 0 8px 0 0;
      overflow: hidden;

      img {
        width: 100%;
      }
    }

    .name {
      font-size: 15px;
      font-weight: bold;
      max-width: 115px;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
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

  .login {
    button {
      padding: 0 8px;
      height: 40px;
      border-radius: 2px;
      display: flex;
      align-items: center;
      color: #fff;
      background: transparent;
      border: 0;
      border-radius: 3px;
      font-size: 13px;
      outline: none;
      cursor: pointer;

      &:hover {
        background: #3f4448;
      }

      span {
        display: flex;
        align-items: center;
      }

      svg {
        fill: #fff;
        width: 20px;
        margin-right: 5px;
      }
    }
  }
}

.el-dropdown-menu {
  .el-dropdown-menu__item {
    display: flex;
    align-items: center;

    svg {
      margin-right: 5px;
      width: 15px;
      fill: #606266;
    }

    &:hover {
      svg {
        fill: #3482d6;
      }
    }
  }
}
</style>


