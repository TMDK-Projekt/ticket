import type { Session, User } from '#drizzle/schema'
import { session } from '#drizzle/schema'
import { encodeBase32LowerCaseNoPadding } from '@oslojs/encoding'
import { eq } from 'drizzle-orm'

export type SessionValidationResult =
  | { session: Session, user: User }
  | { session: null, user: null }

export async function generateSessionToken() {
  const bytes = new Uint8Array(32)
  crypto.getRandomValues(bytes)
  return encodeBase32LowerCaseNoPadding(bytes)
}

export async function createSession(token: string, userId: string) {
  const newSession: Session = {
    id: token,
    userId,
    expiresAt: addDays(new Date(), 30),
  }

  await useDB()
    .insert(session)
    .values(newSession)

  return newSession
}

export async function validateSession(sessionId: string): Promise<SessionValidationResult> {
  const existingSession = await useDB()
    .query
    .session
    .findFirst({
      where: (table, { eq }) => eq(table.id, sessionId),
    })

  if (!existingSession) {
    return { session: null, user: null }
  }

  if (isPast(existingSession.expiresAt)) {
    await invalidateSession(sessionId)
    return { session: null, user: null }
  }

  const existingUser = await useDB()
    .query
    .user
    .findFirst({
      where: (table, { eq }) => eq(table.id, existingSession.userId),
    })

  if (!existingUser) {
    return { session: null, user: null }
  }

  return {
    session: existingSession,
    user: existingUser,
  }
}

export async function invalidateSession(sessionId: string) {
  await useDB()
    .delete(session)
    .where(eq(session.id, sessionId))
}
