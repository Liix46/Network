using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.Application.App.Comments.Commands;

namespace Network.API.Controllers;

[Route("api/comments")]
public class CommentController : AppBaseController
{
    public CommentController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}