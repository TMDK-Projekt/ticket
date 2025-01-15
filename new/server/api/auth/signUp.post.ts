import { localUser, roleToUser, user } from '#drizzle/schema'
import { signUpSchema } from '#shared/auth'
import { zh } from 'h3-zod'
import { Argon2id } from 'oslo/password'
import { serialize } from 'superjson'

export default defineEventHandler(async (event) => {
  const body = await zh.useValidatedBody(event, signUpSchema)

  const [newUser] = await useDB()
    .insert(user)
    .values({
      id: generateIdFromEntropySize(24),
      email: body.email,
      firstName: body.firstName,
      lastName: body.lastName,
      joinDate: startOfDay(new Date()),
    })
    .returning()

  if (!newUser) {
    throw createError({
      statusCode: 500,
      statusMessage: 'Failed to create user',
    })
  }

  const passwordHash = await new Argon2id().hash(body.password)

  await useDB()
    .insert(localUser)
    .values({
      userId: newUser.id,
      password: passwordHash,
    })

  const sessionToken = await generateSessionToken()
  const newSession = await createSession(sessionToken, newUser.id)
  await createAndSetSessionCookie(event, newSession.id)

  await useDB().insert(roleToUser).values({
    userId: newUser.id,
    roleId: 'default',
  })

  return serialize(newUser)
})
