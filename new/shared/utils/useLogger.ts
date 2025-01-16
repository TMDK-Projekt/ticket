export function useLogger(tag?: string) {
  if (tag) {
    return consola.withTag(tag)
  }
  return consola
}
