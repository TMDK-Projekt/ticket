import type { LogWriter } from 'drizzle-orm'
import * as schema from '#drizzle/schema'
import 'dotenv/config'

class ConsolaLogWriter implements LogWriter {
  private logger

  constructor(tag: string) {
    this.logger = useLogger(tag)
  }

  write(message: string) {
    this.logger.info(message)
  }
}

const logger = new DefaultLogger({ writer: new ConsolaLogWriter('db.query') })

export function useDB() {
  return drizzle(env.DATABASE_URL as string, { schema, logger })
}
