import {
  UserLoggedMixin,
  LoaderMixin
} from "./common/mixins";

const GlobalMixins = {
  install(Vue) {
    Vue.mixin(UserLoggedMixin);
    Vue.mixin(LoaderMixin);
  }
};

export default GlobalMixins;