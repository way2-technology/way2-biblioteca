import Vue from "vue";
import state from "./State";
import mutations from "./Mutations";

function createStore({ state: sT, mutations: mT }: any): object {
  return {
    state: Vue.observable(sT),
    commit(key: string, ...args: any) {
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
