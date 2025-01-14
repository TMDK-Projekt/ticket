export default defineNuxtRouteMiddleware(async  () => {
  const user = useUser()
  if(!user.value) {
      await navigateTo("/auth/signIn")
  }
  console.log(user.value)
})