import Vue from 'vue'
import Router from 'vue-router'
import auth from './auth'
import Home from './views/Home.vue'
import Login from './views/Login.vue'
import StandardCakes from './views/StandardCakes.vue'
import OrderCake from './views/OrderCake.vue'
import OrderCustomCake from './views/OrderCustomCake.vue'
import AdminMenu from './views/AdminMenu.vue'
import ConfirmOrder from './views/ConfirmOrder.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/standardcakes',
      name: 'standard-cakes',
      component: StandardCakes,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/standardcakes/:id',
      name: 'order-cake',
      component: OrderCake,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/ordercustomcake',
      name: 'order-custom-cake',
      component: OrderCustomCake,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/adminmenu',
      name: 'admin-menu',
      component: AdminMenu,
      meta: {
        requiresAuth: true
      }
    },
    {
      
      path: '/ordercustomcake/:id',
      name: 'confirm-order',
      component: ConfirmOrder,
      meta: {
        requiresAuth: false
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const user = auth.getUser();

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && !user) {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();

  }
});

export default router;
