<script setup lang="ts">
function signIn() {
  const data = $fetch("http://localhost:8484/user", {
    method: "post",
    body: values.value
  })
}

const values = ref({
  email: null,
  password: null
})
</script>

<template>

  <UiCard>
      <UiCardHeader class="text-center">
        <UiCardTitle>Login</UiCardTitle>
      </UiCardHeader>

    <UiCardContent>

      <UiLabel>E-Mail</UiLabel>
      <UiInput v-model="values.email" type="email"/>

      <UiLabel>Passwort</UiLabel>
      <UiInput v-model="values.password" type="password"/>
    </UiCardContent>

    <UiCardFooter>
      <div class="w-full flex gap-4 justify-end">
        <UiButton as-child variant="secondary">
          <NuxtLink to="/auth/signUp"> Registrieren </NuxtLink>
        </UiButton>
        <UiButton @click="signIn">Anmelden</UiButton>
      </div>
    </UiCardFooter>
  </UiCard>

</template>

<style scoped>

</style>