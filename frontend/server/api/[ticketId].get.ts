export default defineEventHandler(async () => {
  return await $fetch('http://localhost:5028/api/ticket/getTicket/5D244CC3-6226-4323-A9EF-50012E4A014C')
})
