<script lang="ts" setup>
import { computed } from 'vue'
import { base } from './base'
import { cn } from 'tailwind-variants'

type Props = {
  class?: string
}

const props = defineProps<Props>()

const baseClass = computed(() => base({ className: cn('py-8 w-full h-full', props.class) }))
</script>

<template>
  <div class="flex flex-col w-full h-full">
    <nav class="bg-slate-200 p-2">
      <img src="/fanoos.png" alt="" class="aspect-square w-12" />
    </nav>

    <div :class="baseClass">
      <slot />
    </div>
  </div>
</template>
