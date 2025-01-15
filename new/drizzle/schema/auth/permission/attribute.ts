import { text } from 'drizzle-orm/pg-core'
import { authSchema } from '../schema'

export const attribute = authSchema.table('attribute', {
  id: text().primaryKey(),
  description: text(),
})
