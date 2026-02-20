<script lang="ts" setup>
import { field } from './field'

const { container, label } = field()
const containerClass = container()
const labelClass = label()

type Props = {
  title: string
}

const props = defineProps<Props>()
</script>

<template>
  <label :class="containerClass">
    <p dir="auto" :class="labelClass">{{ title }}:</p>

    <slot />
  </label>
</template>
