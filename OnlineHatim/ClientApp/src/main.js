import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import Argon from "./plugins/argon-kit";
import './registerServiceWorker'
import Notifications from 'vue-notification'

Vue.use(Notifications)


Vue.config.productionTip = false;
Vue.use(Argon);
new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
