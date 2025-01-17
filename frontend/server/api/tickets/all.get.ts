export default defineEventHandler(async () => {
    console.log('GETTING TICKETS')
  return await $fetch(`http://localhost:5028/api/ticket/getAllTickets`)
})
