import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router'
import TodoView from '#/views/todo/TodoView.vue'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    name: 'home',
    redirect: '/todo',
  },
  {
    path: '/todo',
    name: 'todo',
    component: TodoView,
  },
]

export const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})
