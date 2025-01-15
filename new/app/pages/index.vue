<script setup lang="ts">
import { z } from 'zod'

definePageMeta({
  permission: 'pages.index',
  middleware: 'protected',
})

const ticketQuery = useQuery({
  queryKey: ['tickets'],
  queryFn: () => $fetch('/api/ticket'),
})

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(z.object({
    reason: z.string(),
    content: z.string(),
  })),
})

const onSubmit = handleSubmit(async (values) => {
  await $fetch('/api/ticket', {
    method: 'POST',
    body: values,
  })
  ticketQuery.refetch()
})
</script>

<template>
  <div>
    <div class="flex flex-col gap-2">
      <Ticket v-for="ticket in ticketQuery.data.value" v-bind="ticket" :key="ticket.id" />
    </div>
  </div>

  <form novalidate @submit.prevent="onSubmit">
    <ValidatedInput label="Reason" name="reason" />
    <ValidatedInput label="Content" name="content" />
    <UiButton>
      Reply
    </UiButton>
  </form>
</template>
