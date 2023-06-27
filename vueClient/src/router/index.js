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
      path: '/rackets',
      name: 'rackets',
      component: () => import('../views/RacketsVue.vue')
    },
    {
      path: '/clothing',
      name: 'clothing',
      component: () => import('../views/ClothingVue.vue')
    },
    {
      path: '/shoes',
      name: 'shoes',
      component: () => import('../views/ShoesVue.vue')
    },
    {
      path: '/accessories',
      name: 'accessories',
      component: () => import('../views/AccessoriesVue.vue')
    },
  ]
})

export default router
