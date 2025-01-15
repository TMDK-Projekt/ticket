<script setup lang="ts">
import type { NuxtError } from '#app'

defineProps({
  error: Object as () => NuxtError,
})

// definePageMeta({
// This does not work yet maybe in the future we will have a use for this
// permission: 'pages.error',
// middleware: 'protected',
// })
</script>

<template>
  <div>
    <h1>{{ error?.statusCode }}</h1>
    <NuxtLink to="/">
      Go back home
    </NuxtLink>
  </div>
</template>
