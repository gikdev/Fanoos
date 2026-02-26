export type TodosResponse = {
  items: TodoResponse[]
}

export type TodoResponse = {
  id: string
  title: string
  rawTitle: string
  context: string | null
  project: string | null
  time: number | null
  tag: string | null
  energy: string | null
  isImportant: boolean
  isUrgent: boolean
  isDone: boolean
}

export const todosRepo = {
  _todos: {
    items: [
      {
        id: '1',
        title: 'Finish homepage UI',
        rawTitle: 'Finish homepage UI',
        context: 'work',
        project: 'webapp',
        time: 30,
        tag: 'frontend',
        energy: '$$$',
        isImportant: true,
        isUrgent: false,
        isDone: false,
      },
      {
        id: '2',
        title: 'Write API documentation',
        rawTitle: 'Write API documentation',
        context: 'study',
        project: 'backend',
        time: 20,
        tag: 'docs',
        energy: '$$',
        isImportant: false,
        isUrgent: true,
        isDone: false,
      },
      {
        id: '3',
        title: 'Daily standup notes',
        rawTitle: 'Daily standup notes',
        context: null,
        project: null,
        time: null,
        tag: null,
        energy: null,
        isImportant: false,
        isUrgent: false,
        isDone: false,
      },
    ],
  } satisfies TodosResponse as TodosResponse,
  getTodos() {
    return structuredClone(this._todos)
  },
  addTodo(todo: TodoResponse) {
    this._todos.items.unshift(todo)
  },
}
