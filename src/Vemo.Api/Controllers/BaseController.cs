using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vemo.Api.Controllers;

/// <summary>
/// Base class for object controllers.
/// </summary>
[ApiController]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    /// <summary>
    /// Gets protected variable to encapsulate request/response and publishing interaction patterns.
    /// </summary>
    /// <returns></returns>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}