using ErrorOr;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.ToggleTodo;

public record ToggleTodoCommand : IRequest<ErrorOr<Todo>> {
    public required Guid Id { get; init; }
    public required bool? IsDone { get; init; }
}
