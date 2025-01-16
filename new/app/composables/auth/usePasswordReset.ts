import type { ChangePasswordWithToken, PasswordResetEmail } from '#shared/auth'
import { deserialize } from 'superjson'

export function usePasswordReset() {
  const user = useUser()

  const passwordResetEmail = useMutation({
    mutationFn: async (body: PasswordResetEmail) => $fetch('/api/auth/password/resetEmail', {
      method: 'POST',
      body,
    }),
  })

  const changePassword = useMutation({
    mutationFn: async (body: ChangePasswordWithToken) => $fetch('/api/auth/password/change', {
      method: 'POST',
      body,
    }),
    onSuccess: async (data) => {
      user.value = deserialize(data)
      await navigateTo('/auth/signIn')
    },
  })

  return {
    passwordResetEmail,
    changePassword,
  }
}
