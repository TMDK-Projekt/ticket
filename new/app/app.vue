<script setup lang="ts">
declare module '#app' {
  interface PageMeta {
    permission?: Attributes
  }
}

useHead({
  titleTemplate: '%s - Flocky',
})
</script>

<template>
  <NuxtLoadingIndicator color="white" />
  <NuxtRouteAnnouncer />

  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>

  <UiToastProvider />
</template>

<style>
@import '@unocss/reset/tailwind.css';

:root {
  font-family:
    Atkinson Hyperlegible,
    sans-serif;
}

html,
body {
  @apply bg-black text-white;
}

* {
  scrollbar-width: thin;
}
</style>
