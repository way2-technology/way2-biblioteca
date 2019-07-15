import Vue from "vue";
import state from "./state";
import mutations from "./mutations";

function createStore({ state, mutations }) {
  return {
    state: Vue.observable(state),
    commit(key, ...args) {
      mutations[key](state, ...args);
    }
  };
}

const store = createStore({
  state,
  mutations
});

export default store;
