import Vue from 'vue'
import Router from 'vue-router'
import store from './store'

import Login from './components/Login.vue'
import Clients from './components/Clients.vue'
import Policies from './components/Policies.vue'
import About from './views/About.vue'

Vue.use(Router)

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [{
            path: '/clients',
            name: 'clients',
            component: Clients,
            meta: {
                admin: true,
                user: true
            }
        },
        {
            path: '/policies',
            name: 'policies',
            component: Policies,
            meta: {
                admin: true
            }
        },
        {
            path: '/about',
            name: 'about',
            component: About,
            meta: {
                admin: true,
                user: true
            }
        },
        {
            path: '/login',
            name: 'login',
            component: Login,
            meta: {
                free: true,
            }
        },
    ]
})

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.free)) {
        return next();
    }
    if (store.state.usuario && store.state.usuario.rol == 'admin' &&
        to.matched.some(record => record.meta.admin)) {
        return next();
    }
    if (store.state.usuario && store.state.usuario.rol == 'user' &&
        to.matched.some(record => record.meta.user)) {
        return next();
    }
    const publicPages = ['/login'];
    if (!publicPages.includes(to.path)) {
        return next('/login');
    }
})

export default router