export default defineNuxtRouteMiddleware(async () => {
  const user = useUser()
  try {
    if (user.value) {
      await useRequestFetch()(`/api/me/${user.value ?? ''}`)
    }
  }
  catch {
    user.value = null
  }
})
