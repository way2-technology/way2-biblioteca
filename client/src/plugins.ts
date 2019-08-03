import {
  Ajax
} from "./plugins/";

const Plugins = {
  install(Vue) {
    Vue.use(Ajax);
  }
};

export default Plugins;