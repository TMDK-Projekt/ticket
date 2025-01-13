<script setup lang="ts">

</script>

<template>

  <UiCard>
      <UiCardHeader class="text-center">
        <UiCardTitle>LogIn</UiCardTitle>
      </UiCardHeader>

    <UiCardContent>

      <UiLabel>Name</UiLabel>
      <UiInput></UiInput>

      <UiLabel>Passwort</UiLabel>
      <UiInput></UiInput>
    </UiCardContent>

    <UiCardFooter>
      <div class="w-full flex gap-4 justify-evenly">
        <UiButton as-child variant="secondary">
          <NuxtLink to="/auth/signUp"> Registrieren </NuxtLink>
        </UiButton>
        <UiButton>Anmelden</UiButton>
      </div>
    </UiCardFooter>
  </UiCard>

</template>

<style scoped>

</style>