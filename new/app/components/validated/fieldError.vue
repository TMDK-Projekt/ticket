<script setup lang="ts">
defineProps<{
  errorMessage?: string
}>()
</script>

<template>
  <div v-if="errorMessage" class="mt-1 flex items-center gap-1 text-sm text-red-500">
    <Icon name="lucide:info" />
    <p>{{ errorMessage }}</p>
  </div>
</template>
