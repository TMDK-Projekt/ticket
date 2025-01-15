import { text, timestamp } from 'drizzle-orm/pg-core'
import { ticket, user } from '../index'
import { ticketSchema } from './index'

export const ticketReply = ticketSchema.table('ticketReply', {
  id: text().primaryKey(),
  userId: text().notNull().references(() => user.id),
  ticketId: text().notNull().references(() => ticket.id),

  content: text().notNull(),

  createdAt: timestamp().notNull(),
})
