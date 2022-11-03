using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Network.API.Controllers;

[Authorize]
[ApiController]
public class AppBaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public AppBaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

}