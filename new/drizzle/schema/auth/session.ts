import type { z } from 'zod'
import { relations } from 'drizzle-orm'
import { text, timestamp } from 'drizzle-orm/pg-core'
import { createInsertSchema, createSelectSchema } from 'drizzle-zod'
import { authSchema } from './schema'
import { user } from './user'

export const session = authSchema.table('session', {
  id: text().primaryKey(),
  userId: text().notNull().references(() => user.id),
  expiresAt: timestamp().notNull(),
})

export const sessionInsertSchema = createInsertSchema(session)
export const sessionSelectSchema = createSelectSchema(session)

export type Session = z.infer<typeof sessionSelectSchema>
export type SessionInsert = z.infer<typeof sessionInsertSchema>

export const sessionRelations = relations(session, ({ one }) => ({
  user: one(user, {
    fields: [session.userId],
    references: [user.id],
  }),
}))
