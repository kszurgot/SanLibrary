using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SanLibrary.Application.Exceptions;
using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Infrastructure.Exceptions;

internal sealed class ErrorHandlerMiddleware : IMiddleware
{
    private bool some = false;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            some = true;
            await HandleErrorAsync(context, exception);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var (error, code) = Map(exception);

        context.Response.StatusCode = (int) code;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
    }

    private static (Error error, HttpStatusCode code) Map(Exception exception)
        => exception switch
        {
            NotFoundException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.NotFound),
            CustomException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.BadRequest),
            _ => (new Error("error", "There was an error."), HttpStatusCode.InternalServerError)
        };

    private record Error(string Code, string Message);

    private static string GetErrorCode(Exception exception)
        => exception.GetType().Name.Replace("Exception", string.Empty);
}