import type { H3Event } from 'h3'

export const sessionCookieName = 'session'

export async function createAndSetSessionCookie(event: H3Event, sessionId: string) {
  setCookie(event, sessionCookieName, sessionId, { maxAge: 60 * 60 * 24 * 30, httpOnly: true, secure: true, sameSite: 'strict' })
}

export async function createAndSetBlankSessionCookie(event: H3Event) {
  setCookie(event, sessionCookieName, '', { maxAge: 0, httpOnly: true, secure: true, sameSite: 'strict' })
}
