<script setup lang="ts">
const { data: tickets } = await useFetch('http://localhost:5028/api/ticket/getAllTickets')

const filter = ref(null)
const filtered = computed(() => {
  return tickets.value
    .sort((a, b) => {
      if (a.status !== b.status) {
        return a.status - b.status
      }
      return new Date(a.createdDate).getTime() - new Date(b.createdDate).getTime()
    })
    .filter(t => !filter.value || t.status === filter.value)
})

const status = {
  0: 'Nicht Zugewiesen',
  1: 'Zugewiesen',
  2: 'Warteliste',
  3: 'Geschlossen',
  9999: 'Alle',
}
</script>

<template>
  {{ tickets }}
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
              :key="useId()"
              class="font-semibold"
              :value="Object.keys(status)[index]"
            >
              {{ stat }}
            </UiSelectItem>
          </UiSelectGroup>
        </UiSelectContent>
      </UiSelect>
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
            {{ ticket.reason }}
          </UiCardTitle>
          <div class="absolute top-4 right-4 font-semibold  flex flex-col">
            <span>
              Status: {{ ticket.status }}
            </span>
            <span>
              Assigneed: {{ ticket.employeeId !== "00000000-0000-0000-0000-000000000000" && ticket.employeeId }}
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

          <UiButton as-child>
            <NuxtLink :to="`/tickets/${ticket.id}`">
              Ticket Bearbeiten
            </NuxtLink>
          </UiButton>
        </UiCardFooter>
      </UiCard>
    </div>
  </div>
  <div v-else class="grow grid place-content-center h-full text-lg font-semibold">
    Meine Tickets
  </div>
</template>
