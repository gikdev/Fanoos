using Fanoos.Application.Todos.CreateTodo;
using Fanoos.Common.Endpoints;
using Fanoos.Common.Extensions;
using Fanoos.Presentation.Todos.Common;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Fanoos.Presentation.Todos;

internal sealed class CreateTodo : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app
            .MapPost("todos", Handle)
            .WithName(nameof(CreateTodo))
            .WithSummary("Create todo")
            .WithTags(ApiTags.Todos)
            .Accepts<CreateTodoRequest>("application/json")
            .Produces<TodoResponse>();
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromBody] CreateTodoRequest request
    ) {
        var validator = new CreateTodoRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) return Results.BadRequest(validationResult.Errors);

        var result = await mediator.Send(MapToCommand(request));
        if (result.IsError) return result.Errors.ToProblem();

        var todo = result.Value;
        return Results.Ok(todo.MapToResponse());
    }

    private static CreateTodoCommand MapToCommand(CreateTodoRequest request) {
        return new CreateTodoCommand {
            RawTitle = request.RawTitle
        };
    }

    private sealed record CreateTodoRequest {
        public required string RawTitle { get; init; }
    }

    private sealed class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest> {
        public CreateTodoRequestValidator() {
            RuleFor(r => r.RawTitle).NotEmpty();
        }
    }
}
