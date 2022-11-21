using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.Application.App.Auth.Commands;
using Network.Application.App.Registration.Commands;
using Network.Application.App.Users.Queries;

namespace Network.API.Controllers;

[Route("api/account")]
public class AccountController : AppBaseController
{
  public AccountController(IMediator mediator) : base (mediator)
  {
  }

  [AllowAnonymous]
  [HttpPost("login")]
  public async Task<IActionResult> Login(SignInCommand passwordSignInCommand)
  {
    var response = await _mediator.Send(passwordSignInCommand);

    if (response.Succeeded)
    {
      return Ok(new {response.Id, response.Username, response.AccessToken});
    }

    return Unauthorized();
  }

  [AllowAnonymous]
  [HttpPost("registration")]
  public async Task<IActionResult> Registration(SignUpCommand signUpCommand)
  {
    var response = await _mediator.Send(signUpCommand);
    if (response.Succeeded)
    {
      return Ok(new {response.Id, response.Username, response.AccessToken});
    }

    return Unauthorized();
  }

  [AllowAnonymous]
  [HttpPost("log-out")]
  public async Task<IActionResult> SignOut(SignOutCommand signOutCommand)
  {
    await _mediator.Send(signOutCommand);
    return Ok();
  }

  
  [Authorize]
  // [AllowAnonymous]
  [HttpGet("current-user")]
  public async Task<IActionResult> GetCurrentUser()
  {
    var user = await _mediator
      .Send(new GetCurrentUserQuery());
    return Ok(user);
  }
}