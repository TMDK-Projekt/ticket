export default defineNuxtRouteMiddleware(async () => {
  const user = useUser()
  try {
    if (user.value.id) {
      await useRequestFetch()(`/api/me/${user.value.id ?? ''}`)
    }
  }
  catch {
    user.value = null
  }
})
