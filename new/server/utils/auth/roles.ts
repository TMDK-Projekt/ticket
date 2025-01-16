import { attributeSet } from '~~/server/utils'

export interface Role {
  name: string
  description?: string
  attributes: Set<Attributes>
}

export const defaultUser = {
  name: 'Default',
  attributes: new Set<Attributes>([
    attributes.api.auth.me,
    attributes.api.auth.signIn,
    attributes.api.auth.signUp,
    attributes.api.auth.signOut,
    attributes.api.auth.password.change,
    attributes.api.auth.password.resetEmail,
    attributes.api.ticket.post,
    attributes.api.ticket.get,

    attributes.pages.index,
    attributes.pages.settings.all,
    attributes.pages.settings.index,
    attributes.pages.settings.account,
  ]),
} as const satisfies Role

export const superUser = {
  name: 'Super',
  attributes: attributeSet,
} as const satisfies Role
