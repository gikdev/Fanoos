<script lang="ts" setup>
import NewTodoForm from './NewTodoForm.vue'
import TodoHeader from './TodoHeader.vue'
import TodosList from './TodosList.vue'
</script>

<template>
  <div class="max-w-120 mx-auto bg-slate-900 h-dvh text-white flex flex-col">
    <TodoHeader />

    <main class="px-4 flex-1 overflow-y-auto">
      <NewTodoForm />

      <TodosList />
    </main>
  </div>
</template>
