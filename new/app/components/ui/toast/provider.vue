<script setup lang="ts">
const { toasts } = useToast()
</script>

<template>
  <ClientOnly>
    <Teleport to="#teleports">
      <div
        v-if="toasts.length > 0"
        class="fixed bottom-4 right-4 min-w-md w-2/9 flex flex-col gap-2"
      >
        <UiToast
          v-for="toast in toasts"
          :key="toast.id"
          v-motion-slide-visible-bottom
          v-bind="toast"
        />
      </div>
    </Teleport>
  </ClientOnly>
</template>
