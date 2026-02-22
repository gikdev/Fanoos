<script setup lang="ts">
import { RouterView } from 'vue-router'
import { Toaster } from 'vue-sonner'
</script>

<template>
  <Toaster :expand="true" theme="system" richColors />
  <RouterView />
</template>
