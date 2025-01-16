import { deserialize } from 'superjson'

export default defineNuxtRouteMiddleware(async () => {
  const user = useUser()

  try {
    user.value = deserialize(await useRequestFetch()('/api/auth/me'))
  }
  catch {
    user.value = null
  }
})
