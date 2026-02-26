<script setup lang="ts">
import SortChip from '../molecules/SortChip.vue'

const props = defineProps<{
  sort: string | null
  sortOptions: string[]
}>()

const emit = defineEmits<{
  sort: [value: string]
}>()
</script>

<template>
  <div class="flex gap-2 mb-4 flex-wrap">
    <SortChip
      v-for="opt in sortOptions"
      :key="opt"
      @click="emit('sort', opt)"
      :active="sort === opt"
    >
      🔽 {{ opt }}
    </SortChip>
  </div>
</template>
