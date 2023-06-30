import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/my-account',
      name: 'my-account',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/MyAccountVue.vue')
    },
    {
      path: '/cart',
      name: 'cart',
      component: () => import('../views/CartVue.vue')
    },
    {
      path: '/cartUserInfo',
      name: 'cart-user-info',
      component: () => import('../views/CartUserInfoVue.vue')
    },
    {
      path: '/cartCheckOrder',
      name: 'cart-check-order',
      component: () => import('../views/CartCheckOrderVue.vue')
    },
    {
      path: '/rackets',
      name: 'rackets',
      component: () => import('../views/RacketsVue.vue')
    },
    {
      path: '/racket/:id',
      name: 'racket-item',
      component: () => import('../components/RacketItem.vue'), props: true
    },
    {
      path: '/clothing',
      name: 'clothing',
      component: () => import('../views/ClothingVue.vue')
    },
    {
      path: '/clothing/:id',
      name: 'clothing-item',
      component: () => import('../components/ClothingItem.vue'), props: true
    },
    {
      path: '/shoes',
      name: 'shoes',
      component: () => import('../views/ShoesVue.vue')
    },
    {
      path: '/shoes/:id',
      name: 'shoes-item',
      component: () => import('../components/ShoesItem.vue'), props: true
    },
    {
      path: '/accessories',
      name: 'accessories',
      component: () => import('../views/AccessoriesVue.vue')
    },
    {
      path: '/accessory/:id',
      name: 'accessory-item',
      component: () => import('../components/AccessoryItem.vue'), props: true
    }
  ],
  scrollBehavior(to, from, savedPosition) {
    // always scroll to top
    return { top: 0 }
  }
})

export default router
