export default defineEventHandler(async (event) => {
  return await $fetch(`http://localhost:5028/api/ticket/getAllTicketsCustomer/${getRouterParams(event).user}`)
})
