using System.Net;
using Microsoft.AspNetCore.Http;
using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Infrastructure.Exceptions;

internal sealed class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleErrorAsync(context, exception);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var (error, code) = Map(exception);
        context.Response.StatusCode = (int) code;
        await context.Response.WriteAsync(error.ToString());
    }

    private static (Error error, HttpStatusCode code) Map(Exception exception)
        => exception switch
        {
            CustomException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.BadRequest),
            _ => (new Error("error", "There was an error."), HttpStatusCode.InternalServerError)
        };

    private record Error(string Code, string Message);

    private static string GetErrorCode(Exception exception)
        => exception.GetType().Name.Replace("Exception", string.Empty);
}