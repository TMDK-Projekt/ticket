import { antfu } from '@antfu/eslint-config'

// @ts-check
import withNuxt from './.nuxt/eslint.config.mjs'

export default withNuxt(
  antfu({
    vue: true,
    typescript: true,
    // {
    // there are somw weird issues with tsconfig.json (defaults i 100% dont need and want)
    // tsconfigPath: './tsconfig.json',
    // },
    formatters: true,
    stylistic: true,
    unicorn: true,
    type: 'app',
  }),
  {
    rules: {
      'ts/no-unsafe-argument': 'off',
      'ts/no-unsafe-call': 'off',
      'vue/no-multiple-template-root': 'off',
      'ts/strict-boolean-expressions': 'off',
    },
  },
)
