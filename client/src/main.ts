import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import Unicon from "./icons";
import ElementUI from "element-ui";
import "./registerServiceWorker";
import "./assets/scss/element.scss";

Vue.use(ElementUI);
Vue.use(Unicon);

Vue.config.ignoredElements = [/^el-/];
Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
