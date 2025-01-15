import { text } from 'drizzle-orm/pg-core'
import { authSchema } from '../schema'

export const role = authSchema.table('role', {
  id: text().primaryKey(),
  name: text().notNull().unique(),
  description: text(),
})
