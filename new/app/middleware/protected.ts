export default defineNuxtRouteMiddleware(async (to, from) => {
  const user = useUser()
  const { addToast } = useToast()

  if (!user.value) {
    return navigateTo('/auth/signIn')
  }

  if (to.meta.permission && !user.value.permissions.has(to.meta.permission)) {
    addToast({
      title: 'Permission Denied',
      message: `You do not have permission to access page "${String(to.name)}" \n because you lack the required permission "${to.meta.permission}"`,
      variant: 'error',
    })
    if (from.path === to.path) {
      return navigateTo('/')
    }
    return navigateTo(from)
  }
})
