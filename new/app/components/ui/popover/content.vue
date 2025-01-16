<script setup lang="ts">
import { type PopoverContentEmits, type PopoverContentProps, useForwardPropsEmits } from 'reka-ui'

const props = defineProps<PopoverContentProps>()
const emits = defineEmits<PopoverContentEmits>()

const forwarded = useForwardPropsEmits(props, emits)
</script>

<template>
  <PopoverPortal>
    <PopoverContent
      v-bind="{ ...forwarded, ...$attrs }"
      align="end"
      class="border border-white rounded-md bg-black p-4 text-white"
    >
      <slot />

      <PopoverArrow class="fill-white" />
    </PopoverContent>
  </PopoverPortal>
</template>
