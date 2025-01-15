import type { EventHandler, EventHandlerRequest } from 'h3'

interface ProtectedEventHandlerParams {
  attribute: Attributes
}

export function protectedEventHandler<T extends EventHandlerRequest, D>(
  params: ProtectedEventHandlerParams,
  handler: EventHandler<T, D>,
): EventHandler<T, D> {
  return defineEventHandler<T>(async (event) => {
    try {
      await hasPermission(params.attribute, event)

      return await handler(event)
    }
    catch (err) {
      return err
    }
  })
}
