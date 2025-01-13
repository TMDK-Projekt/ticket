<template>
  <div class="grid grid-rows-[auto_1fr] min-h-dvh">
    <header class="pt-4 px-4">
      <h2
          class="scroll-m-20 border-b pb-2 text-3xl font-semibold tracking-tight transition-colors first:mt-0"
      >
        Kunden / User ansicht
      </h2>
    </header>
    <main class="h-full overflow-hidden max-w-7xl mx-auto w-full px-4">
        <slot />
    </main>
  </div>
</template>