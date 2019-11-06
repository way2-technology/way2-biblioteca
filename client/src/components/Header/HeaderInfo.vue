<template>
  <div class="header__info">
    <div>
      <div class="actions">
        <button
          type="button"
          class="action__filters"
          :class="{'visible': popoverVisible}"
          @click="popoverVisible = !popoverVisible"
        >
          <el-badge :value="countFilters" :class="{'badge-visible': countFilters > 0}">
            <svg data-v-c7439186="" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="inherit"><path d="M19,2H5A3,3,0,0,0,2,5V6.17a3,3,0,0,0,.25,1.2l0,.06a2.81,2.81,0,0,0,.59.86L9,14.41V21a1,1,0,0,0,.47.85A1,1,0,0,0,10,22a1,1,0,0,0,.45-.11l4-2A1,1,0,0,0,15,19V14.41l6.12-6.12a2.81,2.81,0,0,0,.59-.86l0-.06A3,3,0,0,0,22,6.17V5A3,3,0,0,0,19,2ZM13.29,13.29A1,1,0,0,0,13,14v4.38l-2,1V14a1,1,0,0,0-.29-.71L5.41,8H18.59ZM20,6H4V5A1,1,0,0,1,5,4H19a1,1,0,0,1,1,1Z"></path></svg>
          </el-badge>
        </button>
        <PopoverFilterBooksByCategories v-if="popoverVisible" @close="popoverVisible = false" />
      </div>
      <!-- TODO: [Usuário Logado] Controle de Usuarios no Banco -->
      <!-- <div class="user" v-if="$userLogged">
        <el-dropdown class="user__dropdown" trigger="click" @command="handleDropdownCommand">
          <button type="button" class="btn-dropdown">
            <Avatar :url="$userLogged.avatar" :name="$userLogged.firstName" />
            <i class="el-icon-arrow-down el-icon--right"></i>
          </button>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item icon="el-icon-circle-plus-outline" command="add-book">Novo Livro</el-dropdown-item>
            <el-dropdown-item disabled command="see-books">
              <unicon name="notebooks"></unicon>
              <span>Ver Livros emprestados</span>
            </el-dropdown-item>
            <el-dropdown-item disabled command="see-goals">
              <unicon name="books"></unicon>
              <span>Metas de leitura</span>
            </el-dropdown-item>
            <el-dropdown-item command="logout">
              <unicon name="exit"></unicon>
              <span>Sair</span>
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </div>-->
    </div>

    <!-- TODO: [Usuário Deslogado] Controle de Usuarios no Banco -->
    <!-- <div v-if="!$userLogged">
      <div class="login">
        <GoogleLogin :params="googleParams" :onSuccess="handleGoogleLogin">
          <unicon name="entry"></unicon>
          <strong>ENTRAR</strong>
        </GoogleLogin>
      </div>
    </div>-->
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import EventBus from "@/common/providers/EventBus.ts";
import Avatar from "@/common/components/Avatar.vue";
import PopoverFilterBooksByCategories from "@/components/PopoverFilterBooksByCategories/PopoverFilterBooksByCategories.vue";
import GoogleLogin from "vue-google-login";

export default Vue.extend({
  name: "header-info",
  components: {
    Avatar,
    PopoverFilterBooksByCategories,
    GoogleLogin
  },
  data() {
    return {
      popoverVisible: false,
      googleParams: {
        client_id:
          "730744187365-nidi01d6jh081kqhtuik86ksn9r8i1gr.apps.googleusercontent.com"
      }
    };
  },
  computed: {
    countFilters(): number {
      const { categoriesSelected } = this.$store.state;
      return categoriesSelected.length;
    }
  },
  methods: {
    handleDropdownCommand(command: string): void {
      const { emitEventModalNewBook, handleLogout } = this;

      switch (command) {
        case "add-book":
          emitEventModalNewBook();
          break;
        case "logout":
          handleLogout();
          break;
      }
    },
    handleGoogleLogin(user): void {
      this.$store.commit("LOGIN", { user });
    },
    handleLogout(): void {
      this.$store.commit("LOGOUT");
    },
    emitEventModalNewBook(): void {
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

      &:hover,
      &.visible {
        background: $--color-black-3;
      }

      svg {
        fill: #fff;
        width: 20px;
      }
    }

    .action__filters {
      /deep/ {
        .el-badge {
          display: flex;
        }
        .el-badge__content {
          display: none;
        }
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
        background: $--color-black-3;
      }
    }

    /deep/ .name {
      max-width: 115px;
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;

      @media screen and (max-width: $--breakpoint-mobile) {
        display: none;
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
        background: $--color-black-3;
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


