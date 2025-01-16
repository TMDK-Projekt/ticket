<script setup lang="ts">
const { name, label } = defineProps<{
  label?: string
  name: string
}>()

const { value, errorMessage } = useField(() => name)

const id = computed(() => `input-${name}-${useId()}`)
</script>

<template>
  <div class="w-fit w-full flex flex-col">
    <UiLabel v-if="label" :for="id">
      {{ label }}
    </UiLabel>

    <UiInput v-bind="$attrs" :id v-model="value" :name />

    <ValidatedFieldError :error-message />
  </div>
</template>
