<script setup lang="ts">
function signUp() {
  const data = $fetch("http://localhost:8484/user", {
    method: "post",
    body: values.value
  })
}

const values = ref({
  firstName: null,
  lastName: null,
  email: null,
  password: null
})
</script>

<template>

  <UiCard>
    <UiCardHeader class="text-center">
      <UiCardTitle>Registrieren</UiCardTitle>
    </UiCardHeader>

      <UiCardContent>

        <UiLabel>Vorname</UiLabel>
        <UiInput v-model="values.firstName"/>

        <UiLabel>Nachname</UiLabel>
        <UiInput v-model="values.lastName"/>

        <UiLabel>Email</UiLabel>
        <UiInput v-model="values.email" type="email"/>

        <UiLabel>Passwort</UiLabel>
        <UiInput v-model="values.password" type="password"/>
      </UiCardContent>

      <UiCardFooter>
        <div class="flex gap-4 justify-end">
          <UiButton as-child variant="secondary">
            <NuxtLink to="/auth/signIn"> Login </NuxtLink>
          </UiButton>
          <UiButton @click="signUp">Registrieren</UiButton>
        </div>
      </UiCardFooter>

  </UiCard>

</template>

<style scoped>

</style>