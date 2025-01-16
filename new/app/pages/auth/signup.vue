<script setup lang="ts">
import { signUpSchema } from '#shared/auth'

definePageMeta({
  name: 'SignUp',
})

const { signUp } = useAuth()

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(signUpSchema),
})

const onSubmit = handleSubmit(async (values) => {
  signUp.mutate(values)
})
</script>

<template>
  <div class="max-w-lg w-full flex flex-col gap-4 border rounded-md p-4">
    <form class="flex flex-col gap-2" @submit.prevent="onSubmit">
      <div class="flex gap-2">
        <ValidatedInput name="firstName" label="Firstname" />
        <ValidatedInput name="lastName" label="Lastname" />
      </div>

      <ValidatedInput name="email" label="Email" />
      <ValidatedInput name="password" label="Password" />
      <ValidatedInput name="confirmPassword" label="Confirm Password" />

      <ValidatedFormError
        :is-error="signUp.isError"
        :error="signUp.error"
      />

      <UiButton class="mt-2">
        Sign Up
      </UiButton>
    </form>

    <div class="flex place-content-center items-center">
      <NuxtLink
        to="/auth/signin"
        class="hover:underline"
      >
        Sign In
      </NuxtLink>
    </div>
  </div>
</template>
