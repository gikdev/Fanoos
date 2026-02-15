using ErrorOr;
using Fanoos.Common.Data;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.CreateTodo;

internal sealed class CreateTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork     unitOfWork
) : IRequestHandler<CreateTodoCommand, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(CreateTodoCommand request, CancellationToken cancellationToken) {
        var todo = Todo.FromRaw(request.RawTitle);

        await todoRepository.AddAsync(todo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return todo;
    }
}
