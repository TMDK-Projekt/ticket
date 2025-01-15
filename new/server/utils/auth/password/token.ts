import { resetToken } from '#drizzle/schema'
import { eq } from 'drizzle-orm'
import { sha256 } from 'oslo/crypto'
import { encodeHex } from 'oslo/encoding'

export async function createPasswordResetToken(userId: string): Promise<string> {
  await useDB().delete(resetToken).where(eq(resetToken.userId, userId))

  const tokenId = generateIdFromEntropySize(24)
  const tokenHash = encodeHex(await sha256(new TextEncoder().encode(tokenId)))
  await useDB()
    .insert(resetToken)
    .values({
      tokenHash,
      userId,
      expiresAt: addHours(new Date(), 2),
    })

  return tokenId
}
