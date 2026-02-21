<script lang="ts" setup>
import { listTodosQuery } from '#/common/api/generated/client'
import { useQuery } from '@pinia/colada'

const { data } = useQuery(listTodosQuery)
</script>

<template>
  <h1 class="text-center font-bold text-red-500">Hello home</h1>
  <div class="" v-for="item in data?.items" :key="item.id">
    <input :checked="item.isDone" />
    <p>{{ item.rawTitle }}</p>
  </div>
</template>
