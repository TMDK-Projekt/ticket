export default defineEventHandler(async (event) => {
  const { reply } = await readBody(event)

  return await $fetch(`http://localhost:5028/api/ticket/reply`, {
    method: 'POST',
    body: {
      reply,
    },
  })
})
