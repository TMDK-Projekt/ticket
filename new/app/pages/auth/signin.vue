<script setup lang="ts">
import { signInSchema } from '#shared/auth'

definePageMeta({
  name: 'SignIn',
})

useHead({
  title: 'Sign In',
})

const { signIn } = useAuth()

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(signInSchema),
})

const onSubmit = handleSubmit(async (values) => {
  signIn.mutate(values)
})
</script>

<template>
  <div class="max-w-lg w-full flex flex-col gap-4 border rounded-md p-4">
    <form class="flex flex-col gap-2" @submit.prevent="onSubmit">
      <ValidatedInput name="email" label="Email" />
      <div>
        <ValidatedInput name="password" label="Password" />
        <NuxtLink
          class="text-sm hover:underline"
          to="/auth/password/reset/email"
        >
          Forgot Password?
        </NuxtLink>
      </div>

      <ValidatedFormError
        :is-error="signIn.isError"
        :error="signIn.error"
      />

      <UiButton class="mt-2">
        Sign In
      </UiButton>
    </form>

    <div class="flex place-content-center items-center">
      <NuxtLink
        to="/auth/signup"
        class="hover:underline"
      >
        Sign Up
      </NuxtLink>
    </div>
  </div>
</template>
