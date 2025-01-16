<script setup lang="ts">
import { z } from 'zod'

const reasons = ref([
  {
    value: 'fehlercode',
    description: 'Fehlercode',
  },
  {
    value: 'hardwareproblem',
    description: 'Hardwareproblem',
  },
  {
    value: 'support',
    description: 'Support',
  },
  {
    value: 'softwareUpdates',
    description: 'Software-Updates',
  },
  {
    value: 'sonstiges',
    description: 'Sonstiges',
  },
])

const user = useUser()

const { handleSubmit, setFieldValue, values } = useForm({
  validationSchema: toTypedSchema(z.object({
    customerId: z.string(),
    reason: z.string(),
    description: z.string(),
  })),
  initialValues: {
    customerId: user.value ?? '',
  },
})

const onSubmit = handleSubmit(async (values) => {
  await $fetch('/api/tickets/create', {
    method: 'POST',
    body: values,
  })
})
</script>

<template>
  <UiDialog>
    <UiDialogTrigger>
      <UiButton>
        Ticket erstellen
      </UiButton>
    </UiDialogTrigger>

    <UiDialogContent as="form" @submit="onSubmit()">
      <UiDialogHeader>
        <UiDialogTitle>Ticket erstellen</UiDialogTitle>

        <UiLabel>Grund</UiLabel>
        <UiSelect @update:model-value="(val) => setFieldValue('reason', val)">
          <UiSelectTrigger>
            <UiSelectValue placeholder="Grund" />
          </UiSelectTrigger>
          <UiSelectContent>
            <UiSelectGroup>
              <UiSelectLabel>Gründe</UiSelectLabel>
              <UiSelectItem v-for="reason in reasons" :key="reason.value" :value="reason.value">
                {{ reason.description }}
              </UiSelectItem>
            </UiSelectGroup>
          </UiSelectContent>
        </UiSelect>

        <ValidatedTextarea name="description" label="Antwort" />
      </UiDialogHeader>

      <UiDialogFooter>
        <UiButton @click="onSubmit()">
          Speichern
        </UiButton>
      </UiDialogFooter>
    </UiDialogContent>
  </UiDialog>
</template>
