export function timeAgo(date: Date): string {
  const now = new Date()
  const seconds = Math.floor((now.getTime() - date.getTime()) / 1000)

  const intervals: { [key: string]: number } = {
    year: 31536000,
    month: 2592000,
    week: 604800,
    day: 86400,
    hour: 3600,
    minute: 60,
    second: 1,
  }

  for (const [key, value] of Object.entries(intervals)) {
    const count = Math.floor(seconds / value)
    if (count > 0) {
      return `${count} ${key}${count > 1 ? 's' : ''} ago`
    }
  }

  return 'just now'
}
