<script lang="ts" setup>
import { btn } from '#/common/atoms/btn'
import { input } from '#/common/atoms/input'
import { ref } from 'vue'

const props = defineProps<{
  validator: (value: string) => string | null
  placeholder?: string
  isLoading: boolean
}>()

const inputContent = ref('')
const error = ref<string | null>(null)

const emit = defineEmits<{
  submit: [value: string]
}>()

function onSubmit() {
  const value = inputContent.value.trim()

  const validationError = props.validator?.(value) ?? null

  if (validationError) {
    error.value = validationError
    return
  }

  error.value = null
  emit('submit', value)
  inputContent.value = ''
}
</script>

<template>
  <form @submit.prevent="onSubmit" class="flex flex-col gap-1 mb-4">
    <div class="flex w-full">
      <input
        dir="auto"
        :class="input()"
        v-model="inputContent"
        :placeholder="placeholder || '...'"
      />
      <button :class="btn()" :disabled="isLoading" type="submit">SEND</button>
    </div>

    <p v-if="error" class="text-red-400 text-xs py-1">
      {{ error }}
    </p>
  </form>
</template>
