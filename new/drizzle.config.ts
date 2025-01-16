import { env } from 'node:process'
import { defineConfig } from 'drizzle-kit'
import 'dotenv/config'

export default defineConfig({
  out: './drizzle/migrations',
  schema: './drizzle/schema',
  dialect: 'postgresql',
  dbCredentials: {
    url: env.DATABASE_URL as string,
  },
})
