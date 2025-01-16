import type { MailOptions, Options } from 'nodemailer/lib/smtp-transport'
import { createTransport } from 'nodemailer'

export function useNodeMailer() {
  const { nodemailer } = useRuntimeConfig()
  const transport = createTransport(nodemailer as Options)

  const sendMail = async (options: MailOptions) => transport.sendMail({
    from: nodemailer.from,
    ...options,
  })

  return {
    nodemailer,
    sendMail,
    transport,
  }
}
