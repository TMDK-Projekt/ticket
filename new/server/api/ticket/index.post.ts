import { ticket } from '#drizzle/schema'
import { useValidatedBody, z } from 'h3-zod'
import { uuidv7 } from 'uuidv7'

export default protectedEventHandler(
  {
    attribute: attributes.api.ticket.post,
  },
  async (event) => {
    const { content, reason } = await useValidatedBody(event, z.object({
      content: z.string(),
      reason: z.string(),
    }))

    const newTicket = {
      id: uuidv7(),
      userId: event.context.user!.id,
      reason,
      content,
      createdAt: new Date(),
    }

    await useDB().insert(ticket).values(newTicket)

    return newTicket
  },
)
