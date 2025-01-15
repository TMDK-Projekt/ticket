import { useValidatedParams, z } from 'h3-zod'

export default protectedEventHandler(
  {
    attribute: attributes.api.user.name.get,
  },
  async (event) => {
    const { userId } = await useValidatedParams(event, z.object({
      userId: z.string(),
    }))

    return await useDB().query.user.findFirst({
      where: (table, { eq }) => eq(table.id, userId),
      columns: {
        firstName: true,
        lastName: true,
      },
    })
  },
)
