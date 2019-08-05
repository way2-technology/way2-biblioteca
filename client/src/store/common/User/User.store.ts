import Vue from "vue";
import {
  parseUserToSave,
  getToken,
  getUser,
  setUser,
  unsetUser,
  validateLogin
} from "./User.utils";

export interface IStateUser {
  user: {
    info;
    token: string;
  };
}

const State: IStateUser = {
  user: {
    info: getUser(),
    token: getToken()
  }
};

const Mutations = {
  "USER_LOGIN"(state: IStateUser, payload): void {
    const userParsed: any = parseUserToSave(payload.user);
    const loginIsValid: boolean = validateLogin(Vue, userParsed.email);

    if (loginIsValid) {
      setUser(state, userParsed);
      Vue.prototype.$message.success(`Bem vindo: ${userParsed.fullName}`);
    }
  },
  "USER_LOGOUT"(state: IStateUser): void {
    unsetUser(state);
  }
};

export {
  State as UserState,
  Mutations as UserMutations
};