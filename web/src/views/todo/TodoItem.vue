<script setup lang="ts">
import type { TodoResponse } from '#/common/api/generated/client'
import { listTodosQuery, toggleTodoMutation } from '#/common/api/generated/client'
import { useMutation, useQueryCache } from '@pinia/colada'
import { toast } from 'vue-sonner'

const props = defineProps<{
  task: TodoResponse
}>()

const queryCache = useQueryCache()

const { isLoading, mutate } = useMutation({
  ...toggleTodoMutation(),
  onError: () => toast.error('Sth went wrong.'),
  onSuccess: () => {
    queryCache.invalidateQueries(listTodosQuery())
  },
})

function handleToggle() {
  mutate({
    path: {
      id: props.task.id,
    },
    body: {
      isDone: !props.task.isDone,
    },
  })
}
</script>

<template>
  <div class="flex items-start gap-3 p-3">
    <!-- Checkbox -->
    <button
      @click="handleToggle"
      :disabled="isLoading"
      class="mt-1 h-5 w-5 rounded border flex items-center justify-center shrink-0 disabled:opacity-50"
      :class="task.isDone ? 'bg-neutral-800 border-neutral-800 text-white' : 'border-neutral-400'"
    >
      <span v-if="task.isDone" class="text-xs">✓</span>
    </button>

    <!-- Content -->
    <div class="flex-1 min-w-0">
      <!-- Title Row -->
      <div class="flex items-center gap-2">
        <p
          class="text-sm font-medium truncate flex-1"
          :class="task.isDone && 'line-through text-neutral-400'"
        >
          {{ task.title }}
        </p>

        <!-- Priority Indicators -->
        <span v-if="task.isImportant" class="text-xs">🔥</span>
        <span v-if="task.isUrgent" class="text-xs">⚡</span>
      </div>

      <!-- Metadata Row (only if exists) -->
      <div
        v-if="task.project || task.tag || task.time || task.context"
        class="mt-1 text-xs text-neutral-500 flex flex-wrap gap-2"
      >
        <span v-if="task.context">@{{ task.context }}</span>
        <span v-if="task.project">+{{ task.project }}</span>
        <span v-if="task.tag">#{{ task.tag }}</span>
        <span v-if="task.time">⏱ {{ task.time }}</span>
      </div>
    </div>
  </div>
</template>
