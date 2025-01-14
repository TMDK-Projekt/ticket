export default defineEventHandler(async (event) => {
  return await $fetch(`http://localhost:5028/api/user/getUserName/${getRouterParams(event).userId}`)
})
