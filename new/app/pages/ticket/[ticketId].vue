<script setup lang="ts">
import { z } from 'zod'

const route = useRoute('ticketId')

const ticketQuery = useQuery({
  queryKey: ['ticket', route.params.ticketId],
  queryFn: () => $fetch(`/api/ticket/${route.params.ticketId}`),
})

const ticketReplyQuery = useQuery({
  queryKey: ['ticket-reply', route.params.ticketId],
  queryFn: () => $fetch(`/api/ticket/reply/${route.params.ticketId}`),
})

onServerPrefetch(async () => {
  await ticketQuery.suspense()
  await ticketReplyQuery.suspense()
})

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(z.object({
    content: z.string(),
  })),
})

const onSubmit = handleSubmit(async (values) => {
  await $fetch('/api/ticket/reply', {
    method: 'POST',
    body: {
      ticketId: route.params.ticketId,
      content: values.content,
    },
  })

  ticketReplyQuery.refetch()
})
</script>

<template>
  Ticket:
  <pre>
  {{ ticketQuery.data.value }}
  </pre>
  <div class="h-px w-full bg-white" />
  <h2>
    Replys:
  </h2>
  <pre>
    {{ ticketReplyQuery.data.value }}
  </pre>

  <form novalidate @submit.prevent="onSubmit">
    <ValidatedInput name="content" label="Content" />

    <UiButton>
      Reply
    </UiButton>
  </form>
</template>
