<script setup lang="ts">
import { z } from 'zod'

const route = useRoute()
const { data: ticket, refresh } = await useFetch(`/api/tickets/${route.params.ticketId}`)

const { data: userName } = await useFetch(`/api/user/${ticket.value.customerId}`)

const user = useUser()

const { handleSubmit, setFieldValue } = useForm({
  validationSchema: toTypedSchema(z.object({
    response: z.string(),
  })),
})

const onSubmit = handleSubmit(async (value) => {
  await $fetch('/api/tickets/reply', {
    method: 'POST',
    body: {
      id: route.params.ticketId,
      response: value.response,
    },
  })
  await refresh()
})

async function kiAwnser() {
  const res = await $fetch<string>('/api/tickets/kireply', {
    method: 'post',
    body: {
      prompt: ticket.value!.description,
    },
  })

  setFieldValue('response', res)
}
</script>

<template>
  <div class="flex flex-col gap-4 mt-8">
    <UiCard>
      <UiCardHeader>
        <UiCardTitle class="text-xl">
          {{ ticket.reason }}
        </UiCardTitle>
        <UiCardDescription class="flex flex-col">
          <span>
            User: {{ userName.firstName }} {{ userName.lastName }}
          </span>
          <span>
            Zugewiesener Mitarbeiter: {{ ticket.employeeId }}
          </span>
        </UiCardDescription>
      </UiCardHeader>
      <UiCardContent>
        <span class="text-lg font-bold">
          Beschreibung:
        </span>
        <p v-if="ticket?.description" class="text-lg">
          {{ ticket?.description }}
        </p>
        <p v-else>
          Keine Beschreibung für Ticket: {{ ticket.id }}
        </p>
      </UiCardContent>
    </UiCard>

    <div v-if="ticket.response === ''">
      <div class="flex gap-2 flex-col">
        <form novalidate class="flex gap-2 justify-end flex-col " @submit.prevent="onSubmit">
          <ValidatedTextarea name="response" label="Antwort" />
          <UiButton>Abschicken</UiButton>
        </form>
        <UiButton @click="kiAwnser()">
          Mit KI Vorschlag generieren
        </UiButton>
      </div>
    </div>
    <UiCard v-else>
      <UiCardHeader>
        <UiCardTitle>
          Antwort
        </UiCardTitle>
      </UiCardHeader>
      <UiCardContent>
        <p>
          {{ ticket.response }}
        </p>
      </UiCardContent>
    </UiCard>
  </div>
</template>
