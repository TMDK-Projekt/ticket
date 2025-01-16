// https://nuxt.com/docs/api/configuration/nuxt-config
import { fileURLToPath } from 'node:url'

export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },

  future: {
    compatibilityVersion: 4,
  },

  runtimeConfig: {
    nodemailer: {
      host: 'localhost',
      port: 1025,
      from: 'no-reply@flocky.com',
      fromDisplayName: 'Flocky',
    },
  },

  modules: [
    '@nuxt/eslint',
    '@unocss/nuxt',
    '@nuxt/fonts',
    '@hebilicious/vue-query-nuxt',
    '@vee-validate/nuxt',
    'nuxt-typed-router',
    '@vueuse/nuxt',
    '@vueuse/motion/nuxt',
    'reka-ui/nuxt',
    '@formkit/auto-animate',
    '@nuxt/icon',
  ],

  nitro: {
    imports: {
      presets: [
        'date-fns',
        {
          from: 'consola',
          imports: ['consola'],
        },
        {
          from: 'drizzle-orm',
          imports: ['DefaultLogger', 'LogWriter', 'eq', 'and'],
        },
        {
          from: 'drizzle-orm/node-postgres',
          imports: ['drizzle'],
        },
        {
          from: 'node:process',
          imports: ['env'],
        },
      ],
    },
  },

  imports: {
    presets: [
      'date-fns',
      {
        from: 'consola',
        imports: ['consola'],
      },
    ],
  },

  alias: {
    '#drizzle': fileURLToPath(new URL('./drizzle', import.meta.url)),
  },

  eslint: {
    config: {
      standalone: false,
    },
  },
})
