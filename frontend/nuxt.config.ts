// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-11-01',
  devtools: { enabled: true },
  future: { compatibilityVersion: 4 },
  modules: [
    '@nuxtjs/tailwindcss',
    'shadcn-nuxt',
    '@nuxtjs/color-mode',
    '@formkit/auto-animate',
    '@nuxt/eslint',
    '@vee-validate/nuxt',
  ],
  eslint: {
    config: {
      standalone: false,
    },
  },

  shadcn: {
    /**
     * Prefix for all the imported component
     */
    prefix: 'Ui',
    /**
     * Directory that the component lives in.
     * @default "./components/ui"
     */
    componentDir: './components/ui',
  },
})
