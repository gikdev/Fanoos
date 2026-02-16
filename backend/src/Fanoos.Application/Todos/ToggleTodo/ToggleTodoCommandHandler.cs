using ErrorOr;
using Fanoos.Common.Data;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.ToggleTodo;

internal sealed class ToggleTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork     unitOfWork
) : IRequestHandler<ToggleTodoCommand, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(ToggleTodoCommand request, CancellationToken cancellationToken) {
        Todo? todo = await todoRepository.GetOneByIdAsync(request.Id, cancellationToken);

        if (todo is null) return Error.NotFound(description: "Task was not found");

        todo.UpdateDone(request.IsDone);

        await todoRepository.UpdateAsync(todo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return todo;
    }
}
