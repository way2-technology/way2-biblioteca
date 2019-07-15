<template>
  <div class="header__info">
    <div v-if="!userLoggedIn">
      <div class="actions">
        <div>
          <button type="button" @click="popoverVisible = false">
            <el-badge :value="12">
              <unicon name="filter"></unicon>
            </el-badge>
          </button>
          <PopoverFilterBooks v-model="popoverVisible" />
        </div>
        <div>
          <button type="button" @click="emitEventModalNewBook">
            <unicon name="plus-circle"></unicon>
          </button>
        </div>
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
import Vue from "vue";
import PopoverFilterBooks from "@/components/PopoverFilterBooks/PopoverFilterBooks.vue";
import EventBus from "@/providers/EventBus.js";

export default Vue.extend({
  name: "header-info",
  components: {
    PopoverFilterBooks
  },
  computed: {
    userLoggedIn(): boolean {
      return false; // Implementar usuario do localstorage
    },
    contendPopover() {
      return "<h2>Test</h2>";
    }
  },
  data() {
    return {
      popoverVisible: true
    };
  },
  methods: {
    emitEventModalNewBook() {
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
    margin: 0 10px;

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


