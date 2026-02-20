using ErrorOr;
using Fanoos.Application.Todos.ToggleTodo;
using Fanoos.Common.Api;
using Fanoos.Common.Endpoints;
using Fanoos.Domain.Todos;
using Fanoos.Presentation.Todos.Common;
using FluentValidation;
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
        [FromServices] ISender mediator,
        [FromRoute] Guid id,
        [FromBody] ToggleTodoRequest? request = null
    ) {
        ErrorOr<Todo> result = await mediator.Send(MapToCommand(request, id));

        return result.MatchResponse(item => Results.Ok(item.MapToResponse()));
    }

    private static ToggleTodoCommand MapToCommand(ToggleTodoRequest? request, Guid id) {
        return new ToggleTodoCommand {
            Id = id,
            IsDone = request?.IsDone,
        };
    }

    private sealed record ToggleTodoRequest {
        public bool? IsDone { get; init; }
    }
}
