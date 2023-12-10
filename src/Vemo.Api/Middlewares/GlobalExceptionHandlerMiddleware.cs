using System.Net;
using System.Text.Json;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Dtos;

namespace Vemo.Api.Middlewares;

/// <summary>
/// GlobalExceptionHandlerMiddleware
/// </summary>
public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initialize a new instance of the <see cref="GlobalExceptionHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next"></param>
    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var responseModel = new GenericResponseDto(new List<string> { ex.Message });

            switch (ex)
            {
                case BadRequestException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ConflictException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case ForbiddenException:
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ValidationException e:
                    response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    responseModel.Message = "Validasi error";
                    responseModel.Errors = e.Errors;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var resultResponse = JsonSerializer.Serialize(responseModel, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await response.WriteAsync(resultResponse);
        }
    }
}