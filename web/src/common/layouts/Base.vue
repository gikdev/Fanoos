<script setup lang="ts">
import { computed } from 'vue'
import { base } from './base'

interface Props {
  class?: string
}

const props = defineProps<Props>()

const baseClass = computed(() => base({ className: props.class }))
</script>

<template>
  <div :class="baseClass" v-bind="$attrs">
    <slot />
  </div>
</template>
