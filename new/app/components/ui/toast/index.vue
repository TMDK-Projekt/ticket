<script setup lang="ts">
import type { Toast } from '~/composables'

const props = defineProps<Omit<Toast, 'remainingTime'>>()

// eslint-disable-next-line vue/return-in-computed-property
const style = computed(() => {
  switch (props.variant) {
    case 'success':
      return 'border-green-800 bg-green-800'
    case 'error':
      return 'border-red-800 bg-red-800'
    case 'info':
      return 'border-blue-800 bg-blue-800'
  }
})

const { pauseToast, resumeToast } = useToast()

const progressStyle = computed(() => ({
  width: `${props.progress}%`,
}))
</script>

<template>
  <div
    class="relative w-full flex flex-col gap-2 overflow-hidden border rounded-md p-4 !bg-black"
    :class="[style]"
    @mouseenter="pauseToast(id)"
    @mouseleave="resumeToast(id)"
  >
    <div class="flex justify-between gap-2">
      <span v-if="title" class="truncate text-lg font-bold">
        {{ title }}
      </span>
      <span v-if="variant === 'error'" class="i-mdi-error size-8 min-h-8 min-w-8" :class="[style]" />
      <span v-else-if="variant === 'info'" class="i-mdi-info size-8 min-h-8 min-w-8" :class="[style]" />
      <span v-else-if="variant === 'success'" class="i-mdi-check size-8 min-h-8 min-w-8" :class="[style]" />
    </div>

    <p class="font-semibold">
      {{ message }}
    </p>

    <div class="absolute bottom-0 left-0 h-2 w-full">
      <div
        class="h-full max-w-full rounded-bl-[3px] transition transition-all duration-200"
        :class="[style]"
        :style="progressStyle"
      />
    </div>
  </div>
</template>
