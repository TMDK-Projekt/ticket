<script setup lang="ts">
definePageMeta({
  layout: false,
  title: 'Settings',
  permission: 'pages.settings.all',
  middleware: 'protected',
})

const route = useRoute()
</script>

<template>
  <NuxtLayout name="settings">
    <h1 class="mb-4 text-6xl font-bold">
      {{ route.meta.title }}
    </h1>
    <NuxtPage />
  </NuxtLayout>
</template>
