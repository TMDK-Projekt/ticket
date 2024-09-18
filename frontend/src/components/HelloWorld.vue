<script setup lang="ts">
defineProps<{
  msg: string
}>()

const count = ref(0)
const double = computed(() => count.value * 2)
</script>

<template>
  <h1>{{ msg }}</h1>
  {{ count }}
  {{ double }}
  <button @click="count++">
    Click
  </button>
</template>
