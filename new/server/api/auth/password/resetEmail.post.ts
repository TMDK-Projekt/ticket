import { passwordResetEmailSchema } from '#shared/auth'
import { zh } from 'h3-zod'

export default defineEventHandler(async (event) => {
  const { email } = await zh.useValidatedBody(event, passwordResetEmailSchema)

  const reqUrl = getRequestURL(event)

  const user = await useDB()
    .query
    .user
    .findFirst({
      where: (table, { eq }) => eq(table.email, email),
    })

  if (!user) {
    return
  }

  await checkUserPermissions(user.id, attributes.api.auth.password.resetEmail)

  const token = await createPasswordResetToken(user.id)
  const resetUrl = `${reqUrl.origin}/auth/password/change/${token}`

  const nodeMailer = useNodeMailer()

  await nodeMailer.sendMail({
    to: email,
    subject: 'Reset your password',
    text: `Click the link to reset your password: ${resetUrl}`,
  })
})
