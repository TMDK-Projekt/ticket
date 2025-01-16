import type { SignIn, SignUp } from '#shared/auth'
import { deserialize } from 'superjson'

export function useAuth() {
  const user = useUser()
  const logger = useLogger('useAuth')

  const signUp = useMutation({
    mutationFn: async (body: SignUp) => $fetch('/api/auth/signUp', { method: 'POST', body }),
    onError: (error) => {
      logger.error(error)
    },
    onSuccess: async (data) => {
      user.value = deserialize(data)
      await navigateTo('/')
    },
  })

  const signIn = useMutation({
    mutationFn: async (body: SignIn) => $fetch('/api/auth/signIn', { method: 'POST', body }),
    onError: (error) => {
      logger.error(error)
    },
    onSuccess: async (data) => {
      user.value = deserialize(data)
      await navigateTo('/')
    },
  })

  const signOut = useMutation({
    mutationFn: async () => $fetch('/api/auth/signOut', { method: 'POST' }),
    onError: (error) => {
      logger.error(error)
    },
    onSuccess: async () => {
      user.value = null
      await navigateTo('/auth/signIn')
    },
  })

  return {
    signUp,
    signIn,
    signOut,
  }
}
