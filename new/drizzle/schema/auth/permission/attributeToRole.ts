import { primaryKey, text } from 'drizzle-orm/pg-core'
import { authSchema } from '../schema'
import { attribute } from './attribute'
import { role } from './role'

export const attributeToRole = authSchema.table('attributeToRole', {
  attributeId: text().notNull().references(() => attribute.id),
  roleId: text().notNull().references(() => role.id),
}, table => ({ pk: primaryKey({ columns: [table.attributeId, table.roleId] }) }))
