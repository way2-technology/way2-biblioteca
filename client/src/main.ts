import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import mixins from "./mixins";
import ElementUI from "element-ui";
import Unicon from "./icons";
import locale from "element-ui/lib/locale/lang/pt";
import "./registerServiceWorker";
import "./assets/scss/main.scss";

Vue.use(store);
Vue.use(mixins);
Vue.use(ElementUI, { locale });
Vue.use(Unicon);

Vue.config.ignoredElements = [/^el-/];
Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App)
}).$mount("#app");
