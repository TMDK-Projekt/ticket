<script setup lang="ts">
import { passwordResetEmailSchema } from '#shared/auth'

definePageMeta({
  layout: 'auth',
})

const { passwordResetEmail } = usePasswordReset()

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(passwordResetEmailSchema),
})

const onSubmit = handleSubmit(async (values) => {
  passwordResetEmail.mutate(values)
})
</script>

<template>
  <div class="m-4 w-md">
    <div class="flex flex-col gap-4 border rounded-md p-4">
      <form class="flex flex-col gap-2" @submit.prevent="onSubmit">
        <ValidatedInput name="email" label="Email" />

        <ValidatedFormError
          :is-error="passwordResetEmail.isError"
          :error="passwordResetEmail.error"
        />

        <UiButton class="mt-2">
          Reset Password
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
  </div>
</template>
