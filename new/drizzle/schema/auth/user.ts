import type { z } from 'zod'
import { text, timestamp } from 'drizzle-orm/pg-core'
import { createInsertSchema, createSelectSchema } from 'drizzle-zod'
import { authSchema } from './schema'

export const user = authSchema.table('user', {
  id: text().primaryKey(),

  email: text().unique().notNull(),
  firstName: text().notNull(),
  lastName: text().notNull(),

  joinDate: timestamp().notNull(),
  leaveDate: timestamp(),

  createdAt: timestamp().notNull().defaultNow(),
  updatedAt: timestamp().notNull().defaultNow(),
})

export const userInsertSchema = createInsertSchema(user)
export const userSelectSchema = createSelectSchema(user)

export type User = z.infer<typeof userSelectSchema>
export type UserInsert = z.infer<typeof userInsertSchema>
