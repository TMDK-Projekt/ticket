export default defineEventHandler(async (event) => {
  const body = await readBody(event)
  const user = await $fetch('http://localhost:5028/api/user/logInUser', {
    method: 'POST',
    body: { email: body.email, password: body.password },
  })
  console.log(user)
  return user
})
