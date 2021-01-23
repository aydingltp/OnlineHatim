import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";
import HatimCreate from "@/components/HatimCreate.vue";
import HatimList from "@/components/HatimList.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    },
    {
        path: "/hatim-create",
        name: "HatimCreate",
        component: HatimCreate,
    },
    {
        path: "/hatim-list",
        name: "HatimList",
        component: HatimList,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;