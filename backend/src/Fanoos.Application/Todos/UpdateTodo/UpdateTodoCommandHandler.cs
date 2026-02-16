using ErrorOr;
using Fanoos.Common.Data;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.UpdateTodo;

internal sealed class UpdateTodoCommandHandler(
    ITodoRepository todoRepository,
    IUnitOfWork     unitOfWork
) : IRequestHandler<UpdateTodoCommand, ErrorOr<Todo>> {
    public async Task<ErrorOr<Todo>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken) {
        Todo? todo = await todoRepository.GetOneByIdAsync(request.Id, cancellationToken);

        todo.UpdateTitle(request.RawTitle);

        await todoRepository.UpdateAsync(todo, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return todo;
    }
}
