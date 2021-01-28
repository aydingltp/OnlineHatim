import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home.vue'
import HatimCreate from '../components/HatimCreate.vue'
import HatimList from '../components/HatimList.vue'
import HatimDetail from '../components/HatimDetail.vue'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/hatim-create',
        name: 'HatimCreate',
        component: HatimCreate
    },
    {
        path: '/hatim-list',
        name: 'HatimList',
        component: HatimList
    },
    {
        path: '/:id',
        name: 'HatimDetail',
        component: HatimDetail

    },
    {
        path: '/about',
        name: 'About',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router
