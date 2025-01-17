<script setup lang="ts">
const user = useUser()

definePageMeta({
  layout: 'mitarbeiter',
})

const { data: tickets } = await useFetch(`/api/tickets/${user.value ?? ''}/tickets`)
</script>

<template>
  <div>
    <div class="flex gap-2 w-full justify-end py-4">
      <TicketForm />
    </div>
    <div class="flex flex-col gap-2">
      <UiCard v-for="ticket in tickets" :key="ticket.id" class="relative ">
        <NuxtLink :to="`/tickets/${ticket.id}`">
          <UiCardHeader class="flex flex-row justify-between">
            <UiCardTitle class="text-lg">
              {{ (ticket.reason === '') ? 'Kein Grund angegeben' : ticket.reason }}
            </UiCardTitle>
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
          </UiCardFooter>
        </NuxtLink>
      </UiCard>
    </div>
  </div>
</template>
