<script lang="ts" setup>
import { computed } from 'vue'
import type { VariantProps } from 'tailwind-variants'
import { btn } from './btn'

type Props = VariantProps<typeof btn> & {
  class?: string
}

const props = defineProps<Props>()

const buttonClass = computed(() =>
  btn({
    isIcon: props.isIcon,
    className: props.class ?? '',
  }),
)
</script>

<template>
  <button type="button" :class="buttonClass" v-bind="$attrs">
    <slot />
  </button>
</template>
