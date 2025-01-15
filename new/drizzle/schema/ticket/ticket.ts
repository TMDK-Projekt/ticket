import { text } from 'drizzle-orm/pg-core'
import { user } from '../index'
import { ticketSchema } from './index'

export const ticket = ticketSchema.table('ticket', {
  id: text().primaryKey(),
  userId: text().references(() => user.id),

  reason: text().notNull(),
  content: text().notNull(),

  createdAt: text().notNull(),
})
