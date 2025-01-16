<script setup lang="ts">
defineProps<{
  isError?: Ref<boolean>
  error: Ref<Error | null>
}>()
</script>

<template>
  <div v-show="isError?.value" class="min-h-8 flex items-center gap-1 rounded-md bg-red-500 px-2 py-1 text-white">
    <Icon name="lucide:info" size="24" />
    <p>{{ error.value }}</p>
  </div>
</template>
