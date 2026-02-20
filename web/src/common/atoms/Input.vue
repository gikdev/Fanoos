<script lang="ts" setup>
import { computed } from 'vue';
import { input } from './input'

type Props = {
  class?: string
}

const props = defineProps<Props>()

const finalClass = computed(() => input({ className: props.class ?? "" }))
</script>

<template>
  <input dir="auto" :class="finalClass" v-bind="$attrs" />
</template>
