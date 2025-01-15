import { serialize } from 'superjson'

export default protectedEventHandler({
  attribute: attributes.api.auth.me,
}, event => serialize(event.context.user))
