export default defineEventHandler(async (event) => {
    const body = await readBody(event);
    const user = await $fetch("http://localhost:5028/api/user/createUser", {
        method: "POST",
        body: {firstName: body.firstName, lastName: body.lastName, email: body.email, password: body.password}
    })
    console.log(user);
    return user
})