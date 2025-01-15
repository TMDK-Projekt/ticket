<script setup lang="ts">
defineProps<{
  errorMessage?: string
}>()
</script>

<template>
  <div v-if="errorMessage" class="mt-1 flex items-center gap-1 text-sm text-red-500">
    <div class="bg-red-500 size-4 min-h-4 min-w-4" />
    <p>{{ errorMessage }}</p>
  </div>
</template>
