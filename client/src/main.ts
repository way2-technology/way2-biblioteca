import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import "./registerServiceWorker";

import ElementUI from "element-ui";
import "./assets/scss/element.scss";

import Unicon from './icons';

Vue.use(ElementUI);
Vue.use(Unicon);

Vue.config.ignoredElements = [/^el-/];
Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
