<script setup lang="ts">
const { data: tickets, refresh } = await useFetch('/api/tickets/all')

const user = useUser()

const filter = ref(null)
const filtered = computed(() => tickets.value.filter((t) => {
  return !filter.value || t.status === Number(filter.value)
}),
)

const status = {
  0: 'Nicht Zugewiesen',
  1: 'Zugewiesen',
  2: 'Warteliste',
  3: 'Geschlossen',
  9999: 'Alle',
}

async function assignTicketToMe(v: { ticketId: string }) {
  await $fetch('/api/tickets/assign', {
    method: 'POST',
    body: {
      employeeId: user.value,
      id: v.ticketId,
    },
  })

  await refresh()
}
</script>

<template>
  <div class="flex gap-2 flex-col">
    <div class="mt-5 flex grow justify-end gap-2">
      <UiSelect v-model="filter">
        <UiSelectTrigger>
          <UiSelectValue placeholder="Filter Status" />
        </UiSelectTrigger>
        <UiSelectContent>
          <UiSelectGroup>
            <UiSelectItem
              v-for="(stat, index) in status"
              :key="stat"
              class="font-semibold"
              :value="Object.keys(status)[index]"
            >
              {{ stat }}
            </UiSelectItem>
          </UiSelectGroup>
        </UiSelectContent>
      </UiSelect>
      <UiButton @click="refresh">
        Refresh
      </UiButton>
    </div>
    <div class="flex justify-end">
      <span class="font-semibold text-sm">
        {{ filtered.length }} Tickets
      </span>
    </div>
  </div>

  <div v-if="tickets" class="mt-4">
    <div class="flex gap-4 flex-col w-full">
      <UiCard v-for="ticket in filtered" :key="ticket.id" class="relative">
        <UiCardHeader class="flex flex-row justify-between">
          <UiCardTitle class="text-lg">
            {{ (ticket.reason === '') ? 'Kein Grund angegeben' : ticket.reason }}
          </UiCardTitle>
          <div class="absolute top-6 right-6 font-semibold  flex flex-col">
            <span>
              Status: {{ status[ticket.status] }}
            </span>
          </div>
        </UiCardHeader>
        <UiCardContent>
          <div>
            <p class="leading-7 [&:not(:first-child)]:mt-6">
              {{ ticket.description }}
            </p>
          </div>
        </UiCardContent>
        <UiCardFooter>
          <span class="text-sm font-semibold text-muted-foreground">
            {{ timeAgo(new Date(ticket.createdDate)) }}
          </span>
          <div class="flex gap-2 justify-end w-full">
            <UiButton v-if="ticket.employeeId === user" as-child>
              <NuxtLink :to="`/tickets/${ticket.id}`">
                Ticket Bearbeiten
              </NuxtLink>
            </UiButton>

            <UiButton v-else @click="assignTicketToMe({ ticketId: ticket.id })">
              Mir Zuweisen
            </UiButton>
          </div>
        </UiCardFooter>
      </UiCard>
    </div>
  </div>
  <div v-else class="grow grid place-content-center h-full text-lg font-semibold">
    Meine Tickets
  </div>
</template>
