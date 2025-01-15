export default protectedEventHandler(
  {
    attribute: attributes.api.ticket.get,
  },
  async () => {
    return await useDB().query.ticket.findMany()
  },
)
