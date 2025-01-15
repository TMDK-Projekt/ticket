export default protectedEventHandler({
  attribute: attributes.api.auth.signOut,
}, async (event) => {
  await invalidateSession(event.context.session!.id)
  await createAndSetBlankSessionCookie(event)
})
