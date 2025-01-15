import { useValidatedParams, z } from 'h3-zod'

export default protectedEventHandler(
  {
    attribute: attributes.api.ticket.reply.get,
  },
  async (event) => {
    const { ticketId } = await useValidatedParams(event, z.object({
      ticketId: z.string(),
    }))

    return await useDB()
      .query
      .ticketReply
      .findMany({
        where: (table, { eq }) => eq(table.ticketId, ticketId),
      })
  },
)
