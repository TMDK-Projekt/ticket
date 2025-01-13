import {z} from "zod";

const MIN_PASSWORD_LENGTH = 8
const MAX_PASSWORD_LENGTH = 256
const MIN_USERNAME_LENGTH = 1
const MAX_USERNAME_LENGTH = 64

const messages = {
    username: {
        required: 'Username is required.',
        min: `Name must be at least ${MIN_USERNAME_LENGTH} character long.`,
        max: `Name must be at most ${MAX_USERNAME_LENGTH} characters long.`,
    },
    email: {
        invalid: 'Please enter a valid email address.',
    },
    password: {
        required: 'Password is required.',
        min: `Password must be at least ${MIN_PASSWORD_LENGTH} characters long.`,
        max: `Password must be at most ${MAX_PASSWORD_LENGTH} characters long.`,
        mismatch: 'Passwords do not match.',
    },
}
export const signUpSchema = z.object({
    firstName: z.string()
        .min(MIN_USERNAME_LENGTH, messages.username.min)
        .max(MAX_USERNAME_LENGTH, messages.username.max),
    lastName: z.string()
        .min(MIN_USERNAME_LENGTH, messages.username.min)
        .max(MAX_USERNAME_LENGTH, messages.username.max),
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

