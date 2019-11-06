import Vue from "vue";
import state from "./state";
import mutations from "./mutations";

function createStore({ state: sT, mutations: mT }) {
  return {
    state: Vue.observable(sT),
    commit(key: string, ...args) {
      mT[key](sT, ...args);
    }
  };
}

const store = {
  install() {
    Vue.prototype.$store = createStore({
      state,
      mutations
    });
  }
};

export default store;
