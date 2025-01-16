<script setup lang="ts">
import { changePasswordWithTokenSchema } from '#shared/auth'

definePageMeta({
  layout: 'auth',
})

const route = useRoute('auth-password-change-token')

const { changePassword } = usePasswordReset()

const { handleSubmit } = useForm({
  validationSchema: toTypedSchema(changePasswordWithTokenSchema),
  initialValues: {
    token: route.params.token,
  },
})

const onSubmit = handleSubmit(async (values) => {
  changePassword.mutate(values)
})
</script>

<template>
  <div class="m-4 w-md">
    <div class="flex flex-col gap-4 border rounded-md p-4">
      <form class="flex flex-col gap-2" @submit.prevent="onSubmit">
        <ValidatedInput name="newPassword" label="New Password" />
        <ValidatedInput name="confirmPassword" label="Confirm Password" />

        <ValidatedFormError
          :is-error="changePassword.isError"
          :error="changePassword.error"
        />

        <UiButton class="mt-2">
          Change Password
        </UiButton>
      </form>
    </div>
  </div>
</template>
