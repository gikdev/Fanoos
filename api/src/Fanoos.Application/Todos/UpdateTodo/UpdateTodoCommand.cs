using ErrorOr;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.UpdateTodo;

public record UpdateTodoCommand : IRequest<ErrorOr<Todo>> {
    public required Guid Id { get; init; }
    public required string RawTitle { get; init; }
}
