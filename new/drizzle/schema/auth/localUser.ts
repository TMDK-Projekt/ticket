import type { z } from 'zod'
import { relations } from 'drizzle-orm'
import { primaryKey, text } from 'drizzle-orm/pg-core'
import { createInsertSchema, createSelectSchema } from 'drizzle-zod'
import { authSchema } from './schema'
import { user } from './user'

export const localUser = authSchema.table('localUser', {
  userId: text().notNull().references(() => user.id),
  password: text().notNull(),
}, ({ userId, password }) => ({ pk: primaryKey({ columns: [userId, password] }) }))

export const localUserInsertSchema = createInsertSchema(localUser)
export const localUserSelectSchema = createSelectSchema(localUser)

export type LocalUser = z.infer<typeof localUserSelectSchema>
export type LocalUserInsert = z.infer<typeof localUserInsertSchema>

export const localUserRelations = relations(localUser, ({ one }) => ({
  user: one(user, {
    fields: [localUser.userId],
    references: [user.id],
  }),
}))
