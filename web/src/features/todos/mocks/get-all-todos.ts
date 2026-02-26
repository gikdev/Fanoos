import { http, HttpResponse } from 'msw'
import { todosRepo, type TodosResponse } from './common'

export const getAllTodos = http.get('/api/todos', ({ request }) => {
  const url = new URL(request.url)
  const sort = url.searchParams.get('sort')

  let items = [...todosRepo.getTodos().items]

  if (sort === 'context') {
    items.sort((a, b) => (a.context ?? '').localeCompare(b.context ?? ''))
  }

  if (sort === 'tag') {
    items.sort((a, b) => (a.tag ?? '').localeCompare(b.tag ?? ''))
  }

  return HttpResponse.json({ items })
})

export const getAllTodosFetch = async () => {
  const res = await fetch('/api/todos')
  return (await res.json()) as TodosResponse
}
