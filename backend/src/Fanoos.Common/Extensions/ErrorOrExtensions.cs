using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Fanoos.Common.Extensions;

public static class ErrorOrExtensions {
    public static IResult ToProblem(this List<Error> errors) {
        if (errors.Count == 0)
            return TypedResults.Problem();

        return errors.All(e => e.Type == ErrorType.Validation)
            ? ValidationProblem(errors)
            : ToProblem(errors[0]);
    }

    public static IResult ToProblem(this Error error) {
        var statusCode = error.Type switch {
            ErrorType.Conflict     => StatusCodes.Status409Conflict,
            ErrorType.Validation   => StatusCodes.Status400BadRequest,
            ErrorType.NotFound     => StatusCodes.Status404NotFound,
            ErrorType.Forbidden    => StatusCodes.Status403Forbidden,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _                      => StatusCodes.Status500InternalServerError
        };

        return TypedResults.Problem(
            statusCode: statusCode,
            detail: error.Description,
            title: error.Code
        );
    }

    private static ValidationProblem ValidationProblem(List<Error> errors) {
        // Convert to the RFC 7807 validation dictionary format
        var errorDictionary = errors
            .GroupBy(e => e.Code)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.Description).ToArray()
            );

        return TypedResults.ValidationProblem(errorDictionary);
    }
}
