import { signInSchema } from '#shared/auth'
import { zh } from 'h3-zod'
import { Argon2id } from 'oslo/password'
import { serialize } from 'superjson'

export default defineEventHandler(async (event) => {
  const { email, password } = await zh.useValidatedBody(event, signInSchema)

  const existingUser = await useDB()
    .query
    .user
    .findFirst({
      where: (table, { eq }) => eq(table.email, email),
    })

  if (!existingUser) {
    throw createError({
      statusCode: 401,
      statusMessage: 'User not found',
    })
  }

  const existingLocalUser = await useDB()
    .query
    .localUser
    .findFirst({
      where: (table, { eq }) => eq(table.userId, existingUser.id),
    })

  if (!existingLocalUser) {
    throw createError({
      statusCode: 401,
      statusMessage: 'User not found',
    })
  }

  await checkUserPermissions(existingUser.id, attributes.api.auth.signIn)

  const validPassword = await new Argon2id().verify(existingLocalUser.password, password)

  if (!validPassword) {
    throw createError({
      statusCode: 401,
      statusMessage: 'Invalid password',
    })
  }

  const sessionToken = await generateSessionToken()
  const newSession = await createSession(sessionToken, existingUser.id)
  await createAndSetSessionCookie(event, newSession.id)

  return serialize({
    ...existingUser,
    permissions: await getUserPermissions(existingUser.id),
  })
})
