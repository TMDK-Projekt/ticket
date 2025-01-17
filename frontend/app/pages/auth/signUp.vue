<script setup lang="ts">
import { signUpSchema } from '#shared/validation'

definePageMeta({ layout: false })

const { handleSubmit, values } = useForm({
  validationSchema: toTypedSchema(signUpSchema),
  initialValues: { firstName: 'Tim', lastName: 'Holz', email: 't.t@email.com', password: 'Test1234' },
})

const onSubmit = handleSubmit(async (values) => {
  try {
    console.log(values)
    const user = await $fetch<string>('/api/signUp', {
      method: 'POST',
      body: { firstName: values.firstName, lastName: values.lastName, email: values.email, password: values.password },
    })
    await navigateTo('/')
  }
  catch {
    await navigateTo('/auth/signUp')
  }
})
</script>

<template>
  <div class="w-dvw h-dvh flex items-center place-content-center">
    <UiCard class="w-full max-w-lg" as="form" @submit="onSubmit">
      <UiCardHeader class="text-center">
        <UiCardTitle>Registrieren</UiCardTitle>
      </UiCardHeader>
      <UiCardContent class="flex flex-col gap-2">
        {{ values }}
        <ValidatedInput name="firstName" label="Vorname" />
        <ValidatedInput name="lastName" label="Nachname" />
        <ValidatedInput name="email" label="Email" type="email" />
        <ValidatedInput name="password" label="Passwort" type="password" />
        <ValidatedInput name="confirmPassword" label="Passwort wiederholen" type="password" />
      </UiCardContent>

      <UiCardFooter>
        <div class="w-full flex gap-4 justify-end">
          <UiButton as-child variant="secondary">
            <NuxtLink to="/auth/signIn">
              Login
            </NuxtLink>
          </UiButton>
          <UiButton type="submit" @click="onSubmit">
            Registrieren
          </UiButton>
        </div>
      </UiCardFooter>
    </UiCard>
  </div>
</template>

<style scoped>

</style>
