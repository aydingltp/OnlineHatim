import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import HatimCreate from './views/HatimCreate.vue'
import HatimList from './views/HatimList.vue'
import HatimDetail from './views/HatimDetail.vue'
import HatimGizli from './views/HatimGizli.vue'


Vue.use(Router);

export default new Router({
  linkExactActiveClass: "active",
  mode: 'history',
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/hatim-create",
      name: "HatimCreate",
      component: HatimCreate,
    },
    {
      path: "/hatim-gizli",
      name: "HatimGizli",
      component: HatimGizli,
    },
    {
      path: "/hatim-list",
      name: "HatimList",
      component: HatimList,
    },
    {
      path: "/:id",
      name: "HatimDetail",
      component: HatimDetail,
    }
  ],
  scrollBehavior: (to) => {
    if (to.hash) {
      return { selector: to.hash };
    } else {
      return { x: 0, y: 0 };
    }
  },
});
