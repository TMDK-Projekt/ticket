import type { Session, User } from '#drizzle/schema'
import type { H3Event } from 'h3'
import { verifyRequestOrigin } from 'oslo/request'

export default defineEventHandler(async (event): Promise<void> => {
  const { req, res } = event.node

  if (req.method !== 'GET') {
    const originHeader = getHeader(event, 'Origin') ?? null
    const hostHeader = getHeader(event, 'Host') ?? null

    if (!originHeader || !hostHeader || !verifyRequestOrigin(originHeader, [hostHeader])) {
      res.writeHead(403).end()
      return
    }
  }

  const sessionId = getCookie(event, sessionCookieName) ?? null

  if (!sessionId) {
    setEventContext(event, null, null)
    return
  }

  const { session, user: sessionUser } = await validateSession(sessionId)

  if (session) {
    await createAndSetSessionCookie(event, session.id)
  }
  else {
    await createAndSetBlankSessionCookie(event)
    setEventContext(event, null, null)
    return
  }

  const permissions = await getUserPermissions(sessionUser.id)

  logUserPermissions(sessionUser, permissions)

  setEventContext(event, session, {
    ...sessionUser,
    permissions,
  })
})

export type UserWithPermissions = User & { permissions: Set<Attributes> }

declare module 'h3' {
  interface H3EventContext {
    user: UserWithPermissions | null
    session: Session | null
  }
}

function setEventContext(event: H3Event, session: Session | null, user: UserWithPermissions | null): void {
  event.context.session = session
  event.context.user = user
}
