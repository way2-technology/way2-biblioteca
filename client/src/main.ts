import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import Store from "./store";
import GlobalMixins from "./mixins";
import Unicon from "./icons";
import ElementUI from "element-ui";
import locale from "element-ui/lib/locale/lang/pt";
import "./registerServiceWorker";
import "./assets/scss/main.scss";

Vue.use(ElementUI, { locale });
Vue.use(Store);
Vue.use(GlobalMixins);
Vue.use(Unicon);

Vue.config.ignoredElements = [/^el-/];
Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App)
}).$mount("#app");
