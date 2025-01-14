<script setup lang="ts">
const route = useRoute()
const { data: ticket } = await useFetch(`/api/tickets/${route.params.ticketId}`)
const { data: fromUser } = await useFetch(`/api/user/${ticket.value.customerId}`)
</script>

<template>
  <div class="font-semibold text-lg">
    Von User: {{ fromUser.lastName ?? '' }} {{ fromUser.firstName ?? '' }}
  </div>
  <p v-if="ticket.description">
    {{ ticket.description }}
  </p>
  <p v-else>
    Keine Beschreibung für ticket: {{ ticket.id }}
  </p>

  <div class="flex gap-2 justify-end flex-col ">
    <div>
      <UiLabel>Antwort</UiLabel>
      <UiTextarea default-value="TODO" />
    </div>
    <UiButton>Abschicken</UiButton>
  </div>
</template>

<style scoped>

</style>
