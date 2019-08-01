import { IStateUser } from "./User.store";

const parseUserToSave = (user): void | object => {
  if (!user) {
    return;
  }

  const {
    w3: { Paa: avatar, U3: email, ig: fullName, ofa: firstName }
  } = user;

  return {
    avatar,
    email,
    fullName,
    firstName
  };
};

const getToken = (): string => {
  const token: string = localStorage.getItem("token") || "";
  return token;
};

const getUser = (): object => {
  const user: any = localStorage.getItem("user");
  return JSON.parse(user);
};

const setUser = (state: IStateUser, user): void => {
  state.user.info = user;
  state.user.token = "token";

  localStorage.setItem("token", "token");
  localStorage.setItem("user", JSON.stringify(user));
};

const unsetUser = (state: IStateUser): void => {
  state.user.info = null;
  state.user.token = "";

  localStorage.removeItem("token");
  localStorage.removeItem("user");
};

const validateEmailUser = (email: string): boolean => {
  return new RegExp("[a-zA-Z0-9]+\@way2.com.br").test(email);
};

const validateLogin = (Vue, user): boolean => {
  if (!user) {
    Vue.prototype.$message.error("Oops, Algo deu errado, tente novamente mais tarde!");
    return false;
  }

  if (!validateEmailUser(user)) {
    Vue.prototype.$message.error("Oops, Somente é permitido logar-se com e-mail referente a Way2 Tecnologia.");
    return false;
  }

  return true;
};

export {
  parseUserToSave,
  getToken,
  getUser,
  setUser,
  unsetUser,
  validateLogin
};