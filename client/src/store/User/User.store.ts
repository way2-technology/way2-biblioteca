import { getUserStorage, getUserLogin, setUser, validateEmailUser } from "./User.utils";

const UserState = {
  info: getUserStorage() as any,
  token: localStorage.getItem("token") as string
};

const UserMutations = {
  "USER_LOGIN"(state, userParam: any): boolean | object {
    const user: any = getUserLogin(userParam);

    if (!validateEmailUser(user)) {
      return false;
    }

    setUser(state, user);

    return user;
  },
  "USER_LOGOUT"(state): void {
    state.user.info = null;
    state.user.token = "";

    localStorage.removeItem("token");
    localStorage.removeItem("user");
  }
};

export { UserState, UserMutations };