import { createRouter, createWebHistory } from 'vue-router'
import TodoView from '#/views/todo/TodoView.vue'

export const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      redirect: '/todo',
      // component: HomeView,
    },
    {
      path: '/todo',
      name: 'todo',
      component: TodoView,
    },
  ],
})
