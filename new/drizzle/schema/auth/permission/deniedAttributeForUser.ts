import { relations } from 'drizzle-orm'
import { primaryKey, text } from 'drizzle-orm/pg-core'
import { attribute, user } from '../index'
import { authSchema } from '../schema'

export const deniedAttributeForUser = authSchema.table('deniedAttributeForUser', {
  userId: text().notNull().references(() => user.id),
  attributeId: text().notNull().references(() => attribute.id),
}, table => ({ pk: primaryKey({ columns: [table.userId, table.attributeId] }) }))

export const deniedAttributeForUserRelations = relations(deniedAttributeForUser, ({ one }) => ({
  user: one(user, {
    fields: [deniedAttributeForUser.userId],
    references: [user.id],
  }),
  attribute: one(attribute, {
    fields: [deniedAttributeForUser.attributeId],
    references: [attribute.id],
  }),
}))
