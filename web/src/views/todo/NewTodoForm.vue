<script lang="ts" setup>
import { createTodoMutation, listTodosQuery } from '#/common/api/generated/client'
import { useMutation, useQueryCache } from '@pinia/colada'
import { ref } from 'vue'
import { toast } from 'vue-sonner'

const inputContent = ref('')
const queryCache = useQueryCache()

const { isLoading, mutate } = useMutation({
  ...createTodoMutation(),
  onError: () => toast.error('Sth went wrong.'),
  onSuccess: () => {
    inputContent.value = ''
    queryCache.invalidateQueries(listTodosQuery())
  },
})

function handleSend() {
  mutate({
    body: {
      rawTitle: inputContent.value,
    },
  })
}
</script>

<template>
  <form @submit.prevent="handleSend" class="rounded-md overflow-hidden w-full flex mb-4">
    <input
      v-model="inputContent"
      placeholder="New task..."
      class="min-h-12 py-2 px-4 border-2 border-slate-600 border-e-0 focus:border-sky-600 flex-1 bg-transparent outline-none"
    />

    <button
      :disabled="isLoading"
      class="min-h-12 px-4 cursor-pointer bg-sky-600 disabled:cursor-not-allowed disabled:opacity-50"
      type="submit"
    >
      SEND
    </button>
  </form>
</template>
