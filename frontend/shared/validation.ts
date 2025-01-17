import { z } from 'zod'

const MIN_PASSWORD_LENGTH = 8
const MAX_PASSWORD_LENGTH = 256
const MIN_USERNAME_LENGTH = 1
const MAX_USERNAME_LENGTH = 64

const messages = {
  firstName: {
    required: 'Vorname ist erforderlich.',
    min: `Vorname muss mindestens ${MIN_USERNAME_LENGTH} Zeichen lang sein.`,
    max: `Vorname muss mindestens ${MAX_USERNAME_LENGTH} Zeichen lang sein.`,
  },
  lastName: {
    required: 'Nachname ist erforderlich.',
    min: `Nachname muss mindestens ${MIN_USERNAME_LENGTH} Zeichen lang sein.`,
    max: `Nachname muss mindestens ${MAX_USERNAME_LENGTH} Zeichen lang sein.`,
  },
  email: {
    invalid: 'Bitte eine gültige E-Mail verwenden.',
  },
  password: {
    required: 'Password ist erforderlich.',
    min: `Passwort muss mindestens ${MIN_PASSWORD_LENGTH} Zeichen lang sein.`,
    max: `Passwort muss mindestens ${MAX_PASSWORD_LENGTH} Zeichen lang sein.`,
    mismatch: 'Passwörter stimmen nicht überein.',
  },
}
export const signUpSchema = z.object({
  firstName: z.string()
    .min(MIN_USERNAME_LENGTH, messages.firstName.min)
    .max(MAX_USERNAME_LENGTH, messages.firstName.max),
  lastName: z.string()
    .min(MIN_USERNAME_LENGTH, messages.lastName.min)
    .max(MAX_USERNAME_LENGTH, messages.lastName.max),
  email: z.string()
    .email(messages.email.invalid),
  password: z.string()
    .min(MIN_PASSWORD_LENGTH, messages.password.min)
    .max(MAX_PASSWORD_LENGTH, messages.password.max),
  confirmPassword: z.string()
    .min(MIN_PASSWORD_LENGTH, messages.password.min)
    .max(MAX_PASSWORD_LENGTH, messages.password.max),
}).superRefine((schema, ctx) => {
  if (schema.password !== schema.confirmPassword) {
    ctx.addIssue({
      code: z.ZodIssueCode.custom,
      path: ['confirmPassword'],
      message: messages.password.mismatch,
    })
  }
})

export const signInSchema = z.object({
  email: z.string()
    .email(messages.email.invalid),
  password: z.string()
    .max(MAX_PASSWORD_LENGTH, messages.password.max),
})
