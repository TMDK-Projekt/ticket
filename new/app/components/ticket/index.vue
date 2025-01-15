<script setup lang="ts">
const ticket = defineProps<{
  id: string
  userId: string
  content: string
  createdAt: string
}>()

const user = useAuthedUser()

const ticketUser = useQuery({
  queryKey: ['user', ticket.userId],
  queryFn: () => $fetch(`/api/user/name/${ticket.userId}`),
})

onServerPrefetch(async () => {
  await ticketUser.suspense()
})
</script>

<template>
  <div class="border rounded-md bg-black p-4">
    From User:
    <pre>
      {{ ticketUser.data.value }}
    </pre>

    Ticket:
    <pre>
      {{ ticket }}
    </pre>

    <div v-if="user.permissions.has('api.ticket.reply.post')">
      <UiButton as-child>
        <NuxtLink
          :to="`/ticket/${ticket.id}`"
        >
          Reply
        </NuxtLink>
      </UiButton>
    </div>
  </div>
</template>

<style scoped>

</style>
