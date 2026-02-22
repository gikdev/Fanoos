<script lang="ts" setup>
import { listTodosQuery } from '#/common/api/generated/client'
import { useQuery } from '@pinia/colada'
import TodoItem from './TodoItem.vue'

const { data } = useQuery(listTodosQuery)
</script>

<template>
  <div class="flex flex-col overflow-y-auto gap-2">
    <TodoItem v-for="item in data?.items" :key="item.id" :task="item" />
  </div>
</template>
