export default defineEventHandler(async (event) => {
  return await $fetch(`http://localhost:5028/api/ticket/getAllTicketsCustomer/4C1E465C-38E3-4C22-9C93-658C7F2ACB78`)
})
