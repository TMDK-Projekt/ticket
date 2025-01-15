<script setup lang="ts">
const { name, label } = defineProps<{
  label?: string
  name: string
}>()

const { value, errorMessage } = useField(() => name)

const id = computed(() => `textarea-${name}-${useId()}`)
</script>

<template>
  <div class="w-full flex flex-col">
    <UiLabel v-if="label" :for="id">
      {{ label }}
    </UiLabel>

    <UiTextarea v-bind="$attrs" :id v-model="value" :name />

    <ValidatedFieldError :error-message />
  </div>
</template>
