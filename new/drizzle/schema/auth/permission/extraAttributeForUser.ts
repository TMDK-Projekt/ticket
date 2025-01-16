import { relations } from 'drizzle-orm'
import { primaryKey, text } from 'drizzle-orm/pg-core'
import { attribute, user } from '../index'
import { authSchema } from '../schema'

export const extraAttributeForUser = authSchema.table('extraAttributeForUser', {
  userId: text().notNull().references(() => user.id),
  attributeId: text().notNull().references(() => attribute.id),
}, table => ({ pk: primaryKey({ columns: [table.userId, table.attributeId] }) }))

export const extraAttributeForUserRelations = relations(extraAttributeForUser, ({ one }) => ({
  user: one(user, {
    fields: [extraAttributeForUser.userId],
    references: [user.id],
  }),
  attribute: one(attribute, {
    fields: [extraAttributeForUser.attributeId],
    references: [attribute.id],
  }),
}))
