using ErrorOr;
using Fanoos.Domain.Todos;
using MediatR;

namespace Fanoos.Application.Todos.CreateTodo;

public record CreateTodoCommand : IRequest<ErrorOr<Todo>> {
    public required string RawTitle { get; init; }
}
