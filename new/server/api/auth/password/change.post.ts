import { localUser, resetToken } from '#drizzle/schema'
import { changePasswordWithTokenSchema } from '#shared/auth'
import { eq } from 'drizzle-orm'
import { zh } from 'h3-zod'
import { sha256 } from 'oslo/crypto'
import { encodeHex } from 'oslo/encoding'
import { Argon2id } from 'oslo/password'
import { serialize } from 'superjson'

export default defineEventHandler(async (event) => {
  const { newPassword, token: reqToken } = await zh.useValidatedBody(event, changePasswordWithTokenSchema)

  const tokenHash = encodeHex(await sha256(new TextEncoder().encode(reqToken)))

  const token = await useDB()
    .query
    .resetToken
    .findFirst({
      where: (table, { eq }) => eq(table.tokenHash, tokenHash),
    })

  if (token) {
    await useDB().delete(resetToken).where(eq(resetToken.tokenHash, tokenHash))
  }

  if (!token) {
    throw createError({
      statusCode: 400,
      statusMessage: 'Invalid token',
    })
  }

  await checkUserPermissions(token.userId, attributes.api.auth.password.change)

  if (isPast(token.expiresAt)) {
    throw createError({
      statusCode: 400,
      statusMessage: 'Expired token',
    })
  }

  const newPasswordHash = await new Argon2id().hash(newPassword)

  await useDB()
    .update(localUser)
    .set({
      password: newPasswordHash,
    })

  const sessionToken = await generateSessionToken()
  const newSession = await createSession(sessionToken, token.userId)
  await createAndSetSessionCookie(event, newSession.id)

  const user = await useDB()
    .query
    .user
    .findFirst({
      where: (table, { eq }) => eq(table.id, token.userId),
    })

  return serialize({
    ...user,
    permissions: await getUserPermissions(user!.id),
  })
})
