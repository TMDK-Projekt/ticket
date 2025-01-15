import { attribute, attributeToRole, role } from '#drizzle/schema'

async function insertRole(roleVal: Role) {
  await useDB().insert(role).values({
    id: roleVal.name.toLowerCase(),
    name: roleVal.name,
  }).onConflictDoNothing()

  await useDB()
    .insert(attributeToRole)
    .values(
      [...roleVal.attributes]
        .map(attr => ({
          attributeId: attr,
          roleId: roleVal.name.toLowerCase(),
        })),
    )
    .onConflictDoNothing()
}

export default defineNitroPlugin(async () => {
  await useDB()
    .insert(attribute)
    .values(
      [...attributeSet]
        .map(val => ({ id: val })),
    )
    .onConflictDoNothing()

  await insertRole(defaultUser)
  await insertRole(superUser)
})
