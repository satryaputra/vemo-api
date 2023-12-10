using System.Text.Json;
using Vemo.Application.Dtos;

namespace Vemo.Api.Middlewares;

/// <summary>
/// TokenExceptionHandlerMiddleware
/// </summary>
public class TokenExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initialize a new instance of the <see cref="TokenExceptionHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next"></param>
    public TokenExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (IsExpiredToken(context))
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var responseModel = new GenericResponseDto(new List<string> { "expired_token" });
            var resultResponse = JsonSerializer.Serialize(responseModel, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await context.Response.WriteAsync(resultResponse);
        }
        else if (IsInvalidToken(context))
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            var responseModel = new GenericResponseDto(new List<string> { "invalid_token" });
            var resultResponse = JsonSerializer.Serialize(responseModel, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            await context.Response.WriteAsync(resultResponse);
        }
    }

    /// <summary>
    /// IsExpiredTokenError
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static bool IsExpiredToken(HttpContext context)
    {
        return context.Response.Headers.TryGetValue("WWW-Authenticate", out var authenticateHeaderValues) &&
               authenticateHeaderValues.Any(header =>
                   header.Contains("error_description=\"The token expired"));
    }

    /// <summary>
    /// IsInvalidTokenError
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private static bool IsInvalidToken(HttpContext context)
    {
        return context.Response.Headers.TryGetValue("WWW-Authenticate", out var authenticateHeaderValues) &&
               authenticateHeaderValues.Any(header => header.Contains("Bearer error=\"invalid_token\""));
    }
}