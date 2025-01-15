<script setup lang="ts">
const { signOut } = useAuth()
const user = useAuthedUser()
</script>

<template>
  <header>
    <div class="flex items-center justify-between gap-4 border-b p-4 max-sm:p-2">
      <div class="flex gap-2">
        <UiButton as-child>
          <NuxtLink to="/">
            Home
          </NuxtLink>
        </UiButton>
      </div>

      <UiPopover>
        <UiPopoverTrigger as-child>
          <UiAvatar
            avatar="https://avatars2.githubusercontent.com/u/4567?v=4"
            :firstname="user.firstName"
            :lastname="user.lastName"
          />
        </UiPopoverTrigger>
        <UiPopoverContent class="flex flex-col gap-2">
          <UiButton @click="signOut.mutate()">
            Sign out
          </UiButton>
          <UiButton as-child>
            <NuxtLink to="/settings">
              Settings
            </NuxtLink>
          </UiButton>
        </UiPopoverContent>
      </UiPopover>
    </div>
    <slot />
  </header>
</template>
