using Fanoos.Application.Todos.ListTodos;
using Fanoos.Common.Endpoints;
using Fanoos.Domain.Todos;
using Fanoos.Presentation.Todos.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Fanoos.Presentation.Todos;

internal sealed class ListTodos : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapGet("todos", Handle)
            .WithName(nameof(ListTodos))
            .WithSummary("List todos")
            .WithTags(ApiTags.Todos)
            .Produces<TodoListResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator
    ) {
        List<Todo> todos = await mediator.Send(new ListTodosQuery());

        return Results.Ok(MapToListResponse(todos));
    }

    private sealed record TodoListResponse {
        public required List<TodoResponse> Items { get; init; }
        public required TodoListSummary Summary { get; init; }
    }

    private sealed record TodoListSummary {
        public required IEnumerable<string> Tags { get; init; }
        public required IEnumerable<string> Contexts { get; init; }
        public required IEnumerable<string> Projects { get; init; }
    }

    private static TodoListResponse MapToListResponse(List<Todo> todos) {
        return new TodoListResponse {
            Items = todos.ConvertAll(t => t.MapToResponse()),
            Summary = new() {
                Contexts = todos.Select(t => t.Context ?? "").Where(i => !string.IsNullOrWhiteSpace(i)).ToHashSet(),
                Projects = todos.Select(t => t.Project ?? "").Where(i => !string.IsNullOrWhiteSpace(i)).ToHashSet(),
                Tags = todos.Select(t => t.Tag ?? "").Where(i => !string.IsNullOrWhiteSpace(i)).ToHashSet(),
            }
        };
    }
}
