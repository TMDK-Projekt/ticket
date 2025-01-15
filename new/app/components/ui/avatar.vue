<script setup lang="ts">
const { firstname, lastname } = defineProps<{
  avatar?: string
  firstname?: string
  lastname?: string
}>()

const fallback = computed(() => `${firstname?.at(0)}${lastname?.at(0)}`.toUpperCase())
</script>

<template>
  <AvatarRoot class="grid size-10 min-h-10 min-w-10 place-items-center border rounded-full bg-black">
    <AvatarImage
      :src="avatar ?? ''"
      class="h-full w-full rounded-full"
    />
    <AvatarFallback>
      {{ fallback }}
    </AvatarFallback>
  </AvatarRoot>
</template>
