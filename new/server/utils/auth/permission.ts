import type { User } from '#drizzle/schema'
import type { H3Event } from 'h3'
import { attribute, attributeToRole, role, roleToUser, user } from '#drizzle/schema'
import { eq } from 'drizzle-orm'

export function throwPermissionError(attribute: Attributes): never {
  throw createError({
    statusCode: 401,
    statusMessage: `You dont have the permission for ${attribute}`,
    data: { attribute },
  })
}

export async function hasPermission(attribute: Attributes, event: H3Event): Promise<void> {
  await checkUserPermissions(event.context.user!.id, attribute)
}

export async function checkUserPermissions(userId: User['id'], attribute: Attributes): Promise<void> {
  const userPermissions = await getUserPermissions(userId)
  if (!userPermissions.has(attribute)) {
    throwPermissionError(attribute)
  }
}

export async function getUserPermissions(userId: User['id']): Promise<Set<Attributes>> {
  const startTime = Date.now()

  const [deniedAttributes, extraAttributes] = await useDB().transaction(async (trx) => {
    // maybe use a single table for denies and extras and use a single query im not sure
    const deniedAttributes = await trx.query.deniedAttributeForUser.findMany({
      where: (table, { eq }) => eq(table.userId, userId),
    })
    const extraAttributes = await trx.query.extraAttributeForUser.findMany({
      where: (table, { eq }) => eq(table.userId, userId),
    })

    return [deniedAttributes, extraAttributes]
  })

  const deniedIds = new Set(deniedAttributes.map(attr => attr.attributeId))
  const extraIds = new Set(extraAttributes.map(attr => attr.attributeId))

  const defaultAttributes = await useDB()
    .selectDistinct({ id: attribute.id })
    .from(attribute)
    .leftJoin(attributeToRole, eq(attribute.id, attributeToRole.attributeId))
    .leftJoin(role, eq(attributeToRole.roleId, role.id))
    .leftJoin(roleToUser, eq(role.id, roleToUser.roleId))
    .leftJoin(user, eq(roleToUser.userId, user.id))
    .where(eq(user.id, userId)) as { id: Attributes }[]

  const endTime = Date.now()
  useLogger('permissions').info(`getUserPermissions took ${endTime - startTime}ms`)

  return new Set(
    defaultAttributes
      .map(attr => attr.id)
      .concat([...extraIds] as Attributes[])
      .filter(attrId => !deniedIds.has(attrId)),
  )
}

export function logUserPermissions(user: User, permissions: Set<Attributes>): void {
  useLogger('permission').box(
    'User:',
    JSON.stringify(user, null, 2),
    '\n\nPermissions:',
    permissions,
  )
}
