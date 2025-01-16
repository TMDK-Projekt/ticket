import { useValidatedParams, z } from 'h3-zod'

export default protectedEventHandler(
  {
    attribute: attributes.api.ticket.get,
  },
  async (event) => {
    const { ticketId } = await useValidatedParams(event, z.object({
      ticketId: z.string(),
    }))

    return await useDB().query.ticket.findFirst({
      where: (table, { eq }) => eq(table.id, ticketId),
    })
  },
)
