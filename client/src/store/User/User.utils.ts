const getUserLogin = (user): object => {
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

const getUserStorage = (): object => {
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

export {
  getUserStorage,
  getUserLogin,
  setUser,
  validateEmailUser
};