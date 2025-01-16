import { uuidv7 } from 'uuidv7'

const TOAST_DURATION = 5000
const MAX_TOASTS = 10
const UPDATE_INTERVAL = 100
const MAX_VALUE = 100

type ToastVariants = 'success' | 'error' | 'info'

export interface Toast {
  id: string
  title?: string
  message: string
  variant: ToastVariants
  diesAt: number
  progress: number
  remainingTime: number
  paused: boolean
}

export function useToast() {
  const toasts = useState<Toast[]>('visibleToasts', () => [])
  const backlogToasts = useState<Toast[]>('backlogToasts', () => [])

  function updateProgress() {
    const now = Date.now()
    toasts.value.forEach((toast) => {
      if (toast.paused) {
        return
      }

      const elapsed = now - (toast.diesAt - TOAST_DURATION)
      toast.progress = Math.round((elapsed / TOAST_DURATION) * MAX_VALUE)

      if (toast.progress <= MAX_VALUE) {
        return
      }

      removeToast(toast.id)
    })
  }

  useIntervalFn(updateProgress, UPDATE_INTERVAL)

  function addToast(toast: Pick<Toast, 'title' | 'message' | 'variant'>) {
    const newToast: Toast = {
      ...toast,
      id: uuidv7(),
      diesAt: Date.now() + TOAST_DURATION,
      progress: 0,
      remainingTime: TOAST_DURATION,
      paused: false,
    }

    if (toasts.value.length < MAX_TOASTS) {
      toasts.value.push(newToast)
      return
    }
    backlogToasts.value.push(newToast)
  }

  function removeToast(toastId: Toast['id']) {
    toasts.value = toasts.value.filter(t => t.id !== toastId)

    if (backlogToasts.value.length > 0) {
      const nextToast = backlogToasts.value.shift()
      if (!nextToast) {
        return
      }

      toasts.value.push({
        ...nextToast,
        remainingTime: TOAST_DURATION,
        diesAt: Date.now() + TOAST_DURATION,
      })
    }
  }

  function pauseToast(toastId: Toast['id']) {
    const toast = toasts.value.find(t => t.id === toastId)
    if (!toast) {
      return
    }

    toast.paused = true
    toast.remainingTime = toast.diesAt - Date.now()
  }

  function resumeToast(toastId: Toast['id']) {
    const toast = toasts.value.find(t => t.id === toastId)
    if (!toast) {
      return
    }

    toast.paused = false
    toast.diesAt = Date.now() + toast.remainingTime
  }

  return {
    toasts,
    backlogToasts,
    addToast,
    removeToast,
    pauseToast,
    resumeToast,
  }
}
