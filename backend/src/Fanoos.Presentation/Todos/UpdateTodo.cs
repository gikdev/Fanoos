using Fanoos.Application.Todos.UpdateTodo;
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

internal sealed class UpdateTodo : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapPut("todos/{id:guid}", Handle)
            .WithName(nameof(UpdateTodo))
            .WithSummary("Update todo")
            .WithTags(ApiTags.Todos)
            .Accepts<UpdateTodoRequest>("application/json")
            .Produces<TodoResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender                       mediator,
        [FromRoute]    Guid                          id,
        [FromBody]     UpdateTodoRequest             request
    ) {
        var validator = new UpdateTodoRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

        ErrorOr<Todo> result = await mediator.Send(MapToCommand(request, id));
        if (result.IsError) return result.Errors.ToProblem();

        Todo todo = result.Value;
        return Results.Ok(todo.MapToResponse());
    }

    private static UpdateTodoCommand MapToCommand(UpdateTodoRequest request, Guid id) {
        return new UpdateTodoCommand {
            Id       = id,
            RawTitle = request.RawTitle
        };
    }

    internal sealed record UpdateTodoRequest {
        public required string RawTitle { get; init; }
    }

    internal sealed class UpdateTodoRequestValidator : AbstractValidator<UpdateTodoRequest> {
        public UpdateTodoRequestValidator() {
            RuleFor(r => r.RawTitle).NotEmpty();
        }
    }
}
