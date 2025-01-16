export function useAuthedUser() {
  const user = useUser()
  return computed(() => {
    const userValue = unref(user)
    if (!userValue) {
      throw createError('useAuthedUser() can only be used in protected pages')
    }
    return userValue
  })
}
