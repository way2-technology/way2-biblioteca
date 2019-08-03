interface IStateLoader {
  $loader: {
    active: boolean,
    type: string
  };
}

const LoaderState: IStateLoader = {
  $loader: {
    active: false,
    type: ""
  }
};

const LoaderMutations = {
  "SHOW_LOADER"(state: IStateLoader, payload) {
    state.$loader.type = payload.type;
    state.$loader.active = true;
  },
  "HIDE_LOADER"(state: IStateLoader) {
    state.$loader.type = "";
    state.$loader.active = false;
  }
};

export { LoaderState, LoaderMutations };