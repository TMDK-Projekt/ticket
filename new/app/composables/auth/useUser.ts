import type { UserWithPermissions } from '~~/server/middleware/auth'

export function useUser() {
  return useState<UserWithPermissions | null>('user', () => null)
}
