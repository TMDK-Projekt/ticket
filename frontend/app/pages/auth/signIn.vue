<script setup lang="ts">
import {signInSchema} from "#shared/validation";

const {handleSubmit, values} = useForm({
  validationSchema: toTypedSchema(signInSchema)
})

const onSubmit = handleSubmit((values) => {console.log(values)})
</script>

<template>
  <div class="w-dvw h-dvh flex items-center place-content-center">
  <UiCard class="w-full max-w-lg" @submit="onSubmit">
      <UiCardHeader class="text-center">
        <UiCardTitle>Login</UiCardTitle>
      </UiCardHeader>

    <UiCardContent class="gap-2 flex flex-col">
      {{values}}
      <ValidatedInput name="email" label="Email" type="email" />
      <ValidatedInput name="password" label="Passwort" type="password"/>

    </UiCardContent>

    <UiCardFooter>
      <div class="w-full flex gap-4 justify-end">
        <UiButton as-child variant="secondary">
          <NuxtLink to="/auth/signUp"> Registrieren </NuxtLink>
        </UiButton>
        <UiButton @click="onSubmit">Anmelden</UiButton>
      </div>
    </UiCardFooter>
  </UiCard>
  </div>

</template>

<style scoped>

</style>