<template>
  <div class="grid grid-rows-[auto_1fr] min-h-dvh">
    <AppHeader />
    <main class="h-full overflow-hidden">
      <div class="h-full flex flex-col gap-2 p-4">
        <slot />
      </div>
    </main>
  </div>
</template>
