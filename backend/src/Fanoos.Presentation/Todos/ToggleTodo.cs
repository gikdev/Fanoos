using Fanoos.Application.Todos.ToggleTodo;
using Fanoos.Common.Endpoints;
using Fanoos.Common.Extensions;
using Fanoos.Domain.Todos;
using Fanoos.Presentation.Todos.Common;
using FluentValidation;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Fanoos.Presentation.Todos;

internal sealed class ToggleTodo : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapPatch("todos/{id:guid}/status", Handle)
            .WithName(nameof(ToggleTodo))
            .WithSummary("Toggle todo")
            .WithTags(ApiTags.Todos)
            .Accepts<ToggleTodoRequest>("application/json")
            .Produces<TodoResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender                       mediator,
        [FromRoute]    Guid                          id,
        [FromBody]     ToggleTodoRequest             request
    ) {
        ErrorOr<Todo> result = await mediator.Send(MapToCommand(request, id));
        if (result.IsError) return result.Errors.ToProblem();

        Todo todo = result.Value;
        return Results.Ok(todo.MapToResponse());
    }

    private static ToggleTodoCommand MapToCommand(ToggleTodoRequest request, Guid id) {
        return new ToggleTodoCommand {
            Id       = id,
            IsDone   = request.IsDone,
        };
    }

    internal sealed record ToggleTodoRequest {
        public required bool? IsDone { get; init; }
    }
}
