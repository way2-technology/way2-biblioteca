<template>
  <div class="header__info">
    <div v-if="!userLoggedIn">
      <div class="actions">
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
      <div class="user">
        <div class="content user">
          <figure class="avatar"></figure>
          <span class="info no-mobile">
            <span class="name">Robson Braga de Queiroz</span>
            <small class="role">Desenvolvedor</small>
          </span>
        </div>
      </div>
    </div>
    <div v-else>
      <div class="login">
        <el-button type="plain">
          <unicon name="entry"></unicon>Login
        </el-button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  computed: {
    userLoggedIn(): boolean {
      return false; // Implementar usuario do localstorage
    }
  }
})
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

  .user {
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

  .login {
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
</style>


