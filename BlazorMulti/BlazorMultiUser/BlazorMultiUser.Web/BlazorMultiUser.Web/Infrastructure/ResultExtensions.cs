using BlazorMultiUser.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Infrastructure;

public static class ResultExtensions
{
    public static ActionResult<T> ToWebResponse<T>(this Result<T> result)
    {
        return result.ToWebResponse(
            value => new OkObjectResult(value),
            errors => new BadRequestObjectResult(new ServerValidationProblems(errors)));
    }

    public static ActionResult<T> ToWebResponse<T>(this Result<T> result, Func<T, ActionResult<T>> success)
    {
        return result.ToWebResponse(
            success,
            errors => new BadRequestObjectResult(new ServerValidationProblems(errors)));
    }

    public static ActionResult<T> ToWebResponse<T>(this Result<T> result, Func<T, ActionResult<T>> success,
        Func<IDictionary<string, string[]>, ActionResult<T>> invalid)
    {
        return result switch
        {
            Result<T>.Success(var value) => success(value),
            Result<T>.Invalid(var errors) => invalid(errors),
            _ => throw new ArgumentException("Unsupported result type", nameof(result))
        };
    }

    public static async Task<ActionResult<T>> ToWebResponse<T>(this Task<Result<T>> resultTask)
    {
        var result = await resultTask;
        return result.ToWebResponse();
    }
}