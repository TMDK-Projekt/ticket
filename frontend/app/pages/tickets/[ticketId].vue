<script setup lang="ts">
import { z } from 'zod'

const route = useRoute()
const { data: ticket, refresh } = await useFetch(`/api/tickets/${route.params.ticketId}`)

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(z.object({
    reply: z.string(),
  })),
})

const onSubmit = handleSubmit(async (value) => {
  await $fetch('/api/tickets/reply', {
    method: 'POST',
    body: {
      ticketId: route.params.ticketId,
      reply: value.reply,
    },
  })
  await refresh()
})
</script>

<template>
  <!--  <div class="font-semibold text-lg"> -->
  <!--    Von User: {{ fromUser.lastName ?? '' }} {{ fromUser.firstName ?? '' }} -->
  <!--  </div> -->
  <!--  {{ticket}} -->

  <div class="flex flex-col gap-4 mt-8">
    <UiCard>
      <UiCardHeader>
        <UiCardTitle class="text-xl">
          Ticket
        </UiCardTitle>
        <UiCardDescription class="flex flex-col">
          <span>
            User: {{ ticket.customerId }}

          </span>
          <span>
            Zugewiesener Mitarbeiter: {{ ticket.employeeId === "00000000-0000-0000-0000-000000000000" && "Kein Mitarbeiter Zugewiesen" }}

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

    <p v-if="ticket.response">
      Antwort:
      {{ ticket.response }}
    </p>

    <form v-else novalidate class="flex gap-2 justify-end flex-col " @submit="onSubmit">
      <ValidatedTextarea name="reply" label="Antwort" />
      <UiButton>Abschicken</UiButton>
    </form>
  </div>
</template>
