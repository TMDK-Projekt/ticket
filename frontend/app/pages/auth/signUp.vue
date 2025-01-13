<script setup lang="ts">

</script>

<template>

  <UiCard>
    <UiCardHeader class="text-center">
      <UiCardTitle>SignUp</UiCardTitle>
    </UiCardHeader>
    <UiCardContent>

      <UiLabel>Name</UiLabel>
      <UiInput></UiInput>

      <UiLabel>Email</UiLabel>
      <UiInput type="email"></UiInput>

      <UiLabel>Passwort</UiLabel>
      <UiInput></UiInput>
    </UiCardContent>

    <UiCardFooter>
      <div class="w-full flex gap-4 justify-evenly">
        <UiButton as-child variant="secondary">
          <NuxtLink to="/auth/signIn"> Login </NuxtLink>
        </UiButton>
        <UiButton>Registrieren</UiButton>
      </div>
    </UiCardFooter>
  </UiCard>

</template>

<style scoped>

</style>