import * as VueRouter from 'vue-router';
import * as Vue from 'vue';
import { home } from "./home.js";
import { department } from "./department.js";
import { employee } from "./employee.js";

const routes = [
    { path: '/', component: home },
    { path: '/Employee', component: employee },
    { path: '/Department', component: department }
]

const router = VueRouter.createRouter({
    history: VueRouter.createWebHistory(),
    routes
})

const app = Vue.createApp({})
app.use(router)
app.mount('#app')
export default router