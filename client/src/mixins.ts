import {
  UserLoggedMixin,
  LoaderMixin
} from "./mixins/";

const GlobalMixins = {
  install(Vue) {
    Vue.mixin(UserLoggedMixin);
    Vue.mixin(LoaderMixin);
  }
};

export default GlobalMixins;