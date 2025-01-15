import * as ramda from 'ramda'

export const attributes = {
  api: {
    auth: {
      signOut: 'api.auth.signOut',
      signIn: 'api.auth.signIn',
      signUp: 'api.auth.signUp',
      me: 'api.auth.me',
      password: {
        resetEmail: 'api.auth.password.resetEmail',
        change: 'api.auth.password.change',
      },
    },

    ticket: {
      get: 'api.ticket.get',
      post: 'api.ticket.post',
      // delete: 'api.ticket.delete',
      reply: {
        get: 'api.ticket.reply.get',
        post: 'api.ticket.reply.post',
      },

    },

    user: {
      name: {
        get: 'api.user.user.name.get',
      },
    },

  },
  pages: {
    index: 'pages.index',
    error: 'pages.error',
    settings: {
      all: 'pages.settings.all',
      index: 'pages.settings.index',
      account: 'pages.settings.account',
    },
  },
} as const

export type Attributes = Flatten<typeof attributes>

function extractValues(obj: Record<string, unknown>): Attributes[] {
  return ramda.pipe(
    ramda.values,
    ramda.chain(val => (typeof val === 'object' ? extractValues(val) : [val])),
  )(obj)
}

export const attributeSet = new Set(extractValues(attributes))
