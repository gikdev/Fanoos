import { setupWorker } from 'msw/browser'
import * as todos from '#/features/todos/mocks'
import type { HttpHandler } from 'msw'

const handlers: HttpHandler[] = [...Object.values(todos)]

export async function enableMocking() {
  if (!import.meta.env.DEV) return

  const worker = setupWorker(...handlers)

  const result = await worker.start()

  return result
}
