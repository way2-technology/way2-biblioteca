import Vue from "vue";
import {
  parseUserToSave,
  getUser,
  setUser,
  validateLogin
} from "./User.utils";

const UserState = {
  info: getUser() as any,
  token: localStorage.getItem("token") as string
};

const UserMutations = {
  "USER_LOGIN"(state: any, userParam: any): void {
    const user: any = parseUserToSave(userParam);
    const loginValid: boolean = validateLogin(Vue, user);

    if (loginValid) {
      setUser(state, user);
      Vue.prototype.$message.success(`Bem vindo: ${user.fullName}`);
    }
  },
  "USER_LOGOUT"(state: any): void {
    state.user.info = null;
    state.user.token = "";

    localStorage.removeItem("token");
    localStorage.removeItem("user");
  }
};

export { UserState, UserMutations };