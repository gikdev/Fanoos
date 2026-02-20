using ErrorOr;
using Fanoos.Common.Data;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.DeleteTodo;

internal sealed class DeleteTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteTodoCommand, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken) {
        Todo? todo = await todoRepository.GetOneByIdAsync(request.Id, cancellationToken);

        if (todo is null) return Error.NotFound(description: "Task was not found");

        await todoRepository.RemoveAsync(todo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return todo;
    }
}
