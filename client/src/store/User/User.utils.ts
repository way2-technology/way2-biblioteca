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

const getUser = (): object => {
  const user: any = localStorage.getItem("user");
  return JSON.parse(user);
};

const setUser = (state, user): void => {
  state.user.info = user;
  state.user.token = "token";

  localStorage.setItem("token", "token");
  localStorage.setItem("user", JSON.stringify(user));
};

const validateEmailUser = ({ email }): boolean => {
  return new RegExp("[a-zA-Z0-9]+\@way2.com.br").test(email);
};

const validateLogin = (Vue, user): boolean => {
  if (!user) {
    Vue.prototype.$message.error("Oops, Algo deu errado com o login");
    return false;
  }

  if (!validateEmailUser(user)) {
    Vue.prototype.$message.error("Oops, Somente é permitido logar-se com e-mail referente a Way2 Tecnologia");
    return false;
  }

  return true;
};

export {
  parseUserToSave,
  getUser,
  setUser,
  validateLogin
};