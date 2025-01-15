<script setup lang="ts">
import type { PrimitiveProps } from 'reka-ui'

withDefaults(
  defineProps<PrimitiveProps>(),
  {
    as: 'button',
  },
)
</script>

<template>
  <Primitive
    class="h-8 rounded-md bg-white px-2 py-1 text-black"
    :as
    :as-child="asChild"
  >
    <slot />
  </Primitive>
</template>
