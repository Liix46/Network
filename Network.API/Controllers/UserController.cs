using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.Application.App.Users.Commands;
using Network.Application.App.Users.Queries;

namespace Network.API.Controllers;

[Route("api/users")]
public class UserController  : AppBaseController
{
    public UserController(IMediator mediator) : base (mediator)
    {
    }
    
    [Authorize]
    [HttpGet("{username}")]
    public async Task<IActionResult> GetUser(string username)
    {
        return Ok(await _mediator.Send(new GetUserByUsernameQuery() {Username = username}));
    }

    [Authorize]
    [HttpGet("count-posts/{username}")]
    public async Task<IActionResult> GetCountPostsByUser(string username)
    {
        return Ok(await _mediator.Send(new GetCountPostsByUserQuery() {Username = username}));
    }
    
    [Authorize]
    [HttpGet("count-followers/{username}")]
    public async Task<IActionResult> GetCountFollowersByUser(string username)
    {
        return Ok(await _mediator.Send(new GetCountFollowersQuery() {Username = username}));
    }
    
    [Authorize]
    [HttpGet("count-followings/{username}")]
    public async Task<IActionResult> GetCountFollowingsByUser(string username)
    {
        return Ok(await _mediator.Send(new GetCountFollowingsQuery() {Username = username}));
    }

    [Authorize]
    [HttpDelete("avatar/{username}")]
    public async Task<IActionResult> DeleteAvatarImage(string username)
    {
        return Ok(await _mediator.Send(new DeleteAvatarUserCommand(){Username = username}));
    }

    [Authorize]
    [HttpGet("images/{username}")]
    public async Task<IActionResult> GetUserImages(string username)
    {
        return Ok(await _mediator.Send(new GetUserImagesQuery() {Username = username}));
    }

    [Authorize]
    [HttpPost("search-users")]
    public async Task<IActionResult> GetSearchUsers(GetSearchUsersByUsernameCommand getSearchUsersByUsernameCommand)
    {
        return Ok(await _mediator
            .Send(getSearchUsersByUsernameCommand)
        );
    }

    [Authorize]
    [HttpPost("add-follow")]
    public async Task<IActionResult> PostFollow(PostFollowUserCommand postFollowUserCommand)
    {
        return Ok(await _mediator.Send(postFollowUserCommand));
    }
}