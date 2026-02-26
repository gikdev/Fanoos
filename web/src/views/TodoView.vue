<script lang="ts" setup>
import CreateTodoForm from '#/features/todos/molecules/CreateTodoForm.vue'
import TodoHeader from '#/features/todos/organisms/TodoHeader.vue'
import TodosList from '#/features/todos/organisms/TodosList.vue'
import { useMutation, useQuery, useQueryCache } from '@pinia/colada'
import * as v from 'valibot'
import { createTodoFetch } from '#/features/todos/mocks/create-todo'
import { ref } from 'vue'
import type { TodosResponse } from '#/features/todos/mocks/common'
import TodoSortBar from '#/features/todos/organisms/TodoSortBar.vue'

const sort = ref<string | null>(null)

const schema = v.pipe(
  v.string(),
  v.minLength(1, 'Task title cannot be empty!!!'),
  v.minLength(3, 'Task title is too short!!!'),
)

function validateTodoTitle(value: string): string | null {
  const result = v.safeParse(schema, value)

  return result.success ? null : (result.issues[0]?.message ?? 'Invalid input')
}

const todosQuery = useQuery({
  key: ['todos', sort.value],
  async query() {
    const res = await fetch(`/api/todos?sort=${sort.value}`)
    return (await res.json()) as TodosResponse
  },
})
const mutation = useMutation({
  mutation: createTodoFetch,
  onSuccess: () => {
    todosQuery.refetch()
  },
})

function createTodo(title: string) {
  mutation.mutate(title)
}

function changeSort(value: string) {
  sort.value = (sort.value === value) ? null : value
  todosQuery.refetch()
}
</script>

<template>
  <div class="max-w-120 mx-auto bg-slate-900 h-dvh text-white flex flex-col">
    <TodoHeader />

    <main class="px-4 flex-1 overflow-y-auto">
      <CreateTodoForm :is-loading="mutation.isLoading.value" :validator="validateTodoTitle" @submit="createTodo" />

      <TodoSortBar :sort="sort" @sort="changeSort" :sort-options="['context', 'time', 'tag', 'energy']" />

      <TodosList v-if="todosQuery.status.value === 'success'" :items="todosQuery.data.value?.items ?? []" />
      <p v-else-if="todosQuery.status.value === 'pending'" class="p-4">Loading...</p>
      <p v-else class="p-4 text-red-400">Failed to load todos</p>
    </main>
  </div>
</template>
