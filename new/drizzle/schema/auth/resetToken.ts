import { relations } from 'drizzle-orm'
import { primaryKey, text, timestamp } from 'drizzle-orm/pg-core'
import { authSchema } from './schema'
import { user } from './user'

export const resetToken = authSchema.table('resetToken', {
  tokenHash: text().notNull().unique(),
  userId: text().notNull().references(() => user.id),
  expiresAt: timestamp().notNull(),
}, table => ({ pk: primaryKey({ columns: [table.tokenHash, table.userId, table.expiresAt] }) }))

export const resetTokenRelations = relations(resetToken, ({ one }) => ({
  user: one(user, {
    fields: [resetToken.userId],
    references: [user.id],
  }),
}))
