<template>
  <div class="header__info">
    <div v-if="$userLogged">
      <div class="actions">
        <div>
          <button type="button" @click="popoverVisible = !popoverVisible">
            <el-badge :value="12">
              <unicon name="filter"></unicon>
            </el-badge>
          </button>

          <template v-if="popoverVisible">
            <PopoverFilterBooks @close="popoverVisible = false" />
          </template>
        </div>
      </div>
      <div class="user">
        <el-dropdown trigger="click" @command="handleDropdownCommand">
          <button type="button" class="btn-dropdown">
            <figure class="avatar">
              <img :src="$userLogged.avatar" alt="User Avatar" />
            </figure>
            <span class="name no-mobile">{{ $userLogged.firstName }}</span>
            <i class="el-icon-arrow-down el-icon--right"></i>
          </button>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item icon="el-icon-circle-plus" command="add-book">Novo Livro</el-dropdown-item>
            <el-dropdown-item icon="el-icon-plus" command="see-books">Ver Livros emprestados</el-dropdown-item>
            <el-dropdown-item icon="el-icon-circle-plus" command="see-goals">Metas de leitura</el-dropdown-item>
            <el-dropdown-item command="logout">
              <unicon name="entry"></unicon>Sair
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </div>
    </div>
    <div v-else>
      <div class="login">
        <GoogleLogin :params="googleParams" :onSuccess="handleLoginGoogle">
          <unicon name="entry"></unicon>
          <strong>ENTRAR</strong>
        </GoogleLogin>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import PopoverFilterBooks from "@/components/PopoverFilterBooks/PopoverFilterBooks.vue";
import GoogleLogin from "vue-google-login";
import EventBus from "@/providers/EventBus.js";

export default Vue.extend({
  name: "header-info",
  components: {
    PopoverFilterBooks,
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
  methods: {
    handleLoginGoogle($user: any): void {
      this["$store"].commit("USER_LOGIN", $user);
      this.verifyIfUserLogged();
    },
    verifyIfUserLogged() {
      if (!this["$userLogged"]) {
        this.$message.error("Oops, usuário não permitido.");
      } else {
        const { fullName } = this["$userLogged"];
        this.$message.success(`Bem vindo: ${fullName}`);
      }
    },
    handleLogout(): void {
      this["$store"].commit("USER_LOGOUT");
    },
    handleDropdownCommand(command: string): void {
      switch (command) {
        case "add-book":
          this.emitEventModalNewBook();
          break;
        case "logout":
          this.handleLogout();
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
  > div {
    display: flex;
    align-items: center;
  }

  .actions {
    display: flex;
    width: 70px;
    justify-content: space-around;

    > div,
    button {
      display: flex;
      align-items: center;
      justify-content: center;
      flex-grow: 1;
      position: relative;
    }

    button {
      background: transparent;
      border: 0;
      min-height: 40px;
      cursor: pointer;
      outline: none;

      svg {
        fill: #fff;
        width: 20px;
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
      padding: 0 15px;
      height: 40px;
      margin-left: 1.2rem;
      border-radius: 2px;
      display: flex;
      align-items: center;
      cursor: pointer;
      outline: none;

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
</style>


