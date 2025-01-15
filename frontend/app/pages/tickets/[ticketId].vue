<script setup lang="ts">
import { z } from 'zod'

const route = useRoute()
const { data: ticket, refresh } = await useFetch(`/api/tickets/${route.params.ticketId}`)

const user = useUser()

const { handleSubmit, values } = useForm({
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
</script>

<template>
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

    <div v-if="(ticket.employeeId === user.id) || ticket.response == ''">
      <UiCard>
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
        <UiCardFooter>
          {{ ticket }}
        </UiCardFooter>
      </UiCard>

      <form novalidate class="flex gap-2 justify-end flex-col " @submit="onSubmit">
        {{ values }}
        <ValidatedTextarea name="response" label="Antwort" />
        <UiButton>Abschicken</UiButton>
      </form>
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
      <UiCardFooter>
        {{ ticket }}
      </UiCardFooter>
    </UiCard>
    </div>


</template>
