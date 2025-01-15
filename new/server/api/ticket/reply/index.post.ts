import { ticketReply } from '#drizzle/schema'
import { useValidatedBody, z } from 'h3-zod'
import { uuidv7 } from 'uuidv7'

export default protectedEventHandler(
  {
    attribute: attributes.api.ticket.reply.post,
  },
  async (event) => {
    const { ticketId, content } = await useValidatedBody(event, z.object({
      ticketId: z.string(),
      content: z.string(),
    }))

    const newTicketReply = {
      id: uuidv7(),
      ticketId,
      userId: event.context.user!.id,
      content,
      createdAt: new Date(),
    }

    await useDB().insert(ticketReply).values(newTicketReply)

    return newTicketReply
  },
)
