import UserLoggedMixin from "@/mixins/UserLogged.mixin";

const GlobalMixins = {
  install(Vue: any) {
    Vue.mixin(UserLoggedMixin);
  }
};

export default GlobalMixins;