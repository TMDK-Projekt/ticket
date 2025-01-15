import { primaryKey, text } from 'drizzle-orm/pg-core'
import { authSchema } from '../schema'
import { user } from '../user'
import { role } from './role'

export const roleToUser = authSchema.table('roleToUser', {
  roleId: text().notNull().references(() => role.id),
  userId: text().notNull().references(() => user.id),
}, table => ({ pk: primaryKey({ columns: [table.roleId, table.userId] }) }))
