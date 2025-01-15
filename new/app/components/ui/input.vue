<script setup lang="ts" generic="T">
const value = defineModel<T>()
</script>

<template>
  <input v-bind="$attrs" v-model="value" class="h-8 border border-white rounded-md bg-black px-2 py-1">
</template>
