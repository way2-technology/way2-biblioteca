import {
  Ajax
} from "./common/plugins";

const Plugins = {
  install(Vue) {
    Vue.use(Ajax);
  }
};

export default Plugins;