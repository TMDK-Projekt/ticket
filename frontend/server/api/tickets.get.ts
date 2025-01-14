import { env } from 'node:process'

export default defineEventHandler(async () => {
  return $fetch(`${env.API_URL!}/tickets`)
})
