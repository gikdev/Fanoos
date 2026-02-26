import { http, HttpResponse } from 'msw'

type TodoListResponse = {
  items: TodoResponse[]
  summary: TodoListSummary
}

type TodoListSummary = {
  tags: string[]
  contexts: string[]
  projects: string[]
}

type TodoResponse = {
  id: string
  title: string
  rawTitle: string
  context: null | string
  project: null | string
  time: null | string
  tag: null | string
  energy: null | string
  isImportant: boolean
  isUrgent: boolean
  isDone: boolean
}

export const getAllTodos = http.get('/api/todos', () => {
  return HttpResponse.json({
    items: [],
    summary: {
      contexts: [],
      projects: [],
      tags: [],
    },
  } satisfies TodoListResponse)
})
