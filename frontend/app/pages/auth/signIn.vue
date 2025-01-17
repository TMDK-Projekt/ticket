<script setup lang="ts">
import { signInSchema } from '#shared/validation'

definePageMeta({ layout: false })

const { handleSubmit, values } = useForm({
  validationSchema: toTypedSchema(signInSchema),
  initialValues: { email: 'test@test.com', password: 'test' },
})

const userCookie = useUser()

const onSubmit = handleSubmit(async (values) => {
  try {
    const user = await $fetch<string>('/api/signIn', {
      method: 'POST',
      body: { email: values.email, password: values.password },
    })
    if (user === '00000000-0000-0000-0000-000000000000') {
      userCookie.value = null
      return
    }
    userCookie.value = user
    await navigateTo('/')
  }
  catch {
    userCookie.value = null
    await navigateTo('/auth/signIn')
  }
})
</script>

<template>
  <div class="w-dvw h-dvh flex items-center place-content-center">
    <UiCard class="w-full max-w-lg" @submit="onSubmit">
      <UiCardHeader class="text-center">
        <UiCardTitle>Login</UiCardTitle>
      </UiCardHeader>

      <UiCardContent class="gap-2 flex flex-col">
        <ValidatedInput name="email" label="Email" type="email" />
        <ValidatedInput name="password" label="Passwort" type="password" />
      </UiCardContent>

      <UiCardFooter>
        <div class="w-full flex gap-4 justify-end">
          <UiButton as-child variant="secondary">
            <NuxtLink to="/auth/signUp">
              Registrieren
            </NuxtLink>
          </UiButton>
          <UiButton @click="onSubmit">
            Anmelden
          </UiButton>
        </div>
      </UiCardFooter>
    </UiCard>
  </div>
</template>

<style scoped>

</style>
