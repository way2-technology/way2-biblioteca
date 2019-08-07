interface IStateLoader {
  loader: {
    active: boolean,
    type: string
  };
}

const State: IStateLoader = {
  loader: {
    active: false,
    type: ""
  }
};

const Mutations = {
  "SHOW_LOADER"(state: IStateLoader, { type }) {
    state.loader.type = type;
    state.loader.active = true;
  },
  "HIDE_LOADER"(state: IStateLoader) {
    state.loader.type = "";
    state.loader.active = false;
  }
};

export {
  State as LoaderState,
  Mutations as LoaderMutations
};