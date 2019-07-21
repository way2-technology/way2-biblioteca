import state from "../state";
import { getUser, setUser, validateUser } from "./User.utils";

const UserState = {
  info: getUser() as any,
  token: localStorage.getItem("token") as string
};

const UserMutations = {
  "USER_LOGIN"(userParam: any): void {
    if (!validateUser(userParam)) {
      alert("INVALID USER");
      return;
    }

    setUser(state, userParam);
  },
  "USER_LOGOUT"(): void {
    state.user.info = null;
    state.user.token = "";

    localStorage.removeItem("token");
    localStorage.removeItem("user");
  }
};

export { UserState, UserMutations };