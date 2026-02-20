using ErrorOr;
using Fanoos.Application.Todos.DeleteTodo;
using Fanoos.Common.Api;
using Fanoos.Common.Endpoints;
using Fanoos.Domain.Todos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Fanoos.Presentation.Todos;

internal sealed class DeleteTodo : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapDelete("todos/{id:guid}", Handle)
            .WithName(nameof(DeleteTodo))
            .WithSummary("Delete todo")
            .WithTags(ApiTags.Todos)
            .Produces(StatusCodes.Status204NoContent);
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender sender,
        [FromRoute] Guid id
    ) {
        ErrorOr<Todo> result = await sender.Send(new DeleteTodoCommand(id));

        return result.MatchResponse();
    }
}
