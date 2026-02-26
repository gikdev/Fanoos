<script setup lang="ts">
defineProps<{
  active?: boolean
}>()

const emit = defineEmits<{
  click: []
}>()
</script>

<template>
  <button
    @click="emit('click')"
    class="px-3 py-1 rounded-full text-xs border"
    :class="active ? 'bg-sky-600 border-sky-600' : 'border-neutral-500'"
  >
    <slot />
  </button>
</template>
