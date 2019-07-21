const getUser = (): object => {
  const user: any = localStorage.getItem("user");
  return JSON.parse(user);
};

const getParsedUser = (user): object => {
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

const setUser = (state, user): void => {
  const userParsed = getParsedUser(user);

  state.user.info = userParsed;
  state.user.token = "token";

  localStorage.setItem("token", "token");
  localStorage.setItem("user", JSON.stringify(userParsed));
};

const validateUser = (user): boolean => {
  return true;
};

export {
  getUser,
  setUser,
  validateUser
};