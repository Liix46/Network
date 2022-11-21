using MediatR;
using Microsoft.AspNetCore.Identity;
using Network.Application.App.Auth.Responses;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;

namespace Network.Application.App.Auth.Commands;

public class SignInCommand : IRequest<SingInDto>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class SignInCommandHandler : IRequestHandler<SignInCommand, SingInDto>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public SignInCommandHandler(IAuthenticationService authenticationService, ITokenService tokenService, UserManager<User> userManager)
    {
        _authenticationService = authenticationService;
        _tokenService = tokenService;
        _userManager = userManager;
    }
    public async Task<SingInDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var passwordSignInResult = request.Password != null && request.UserName != null && await _authenticationService.PasswordSignInAsync(request.UserName, request.Password);
        string? accessToken = null;
        var user = new User();
        if (passwordSignInResult)
        {
            user = await _userManager.FindByNameAsync(request.UserName);
            accessToken = _tokenService.GenerateAccessToken(user);
        }

        return new SingInDto()
        {
            Succeeded = passwordSignInResult,
            AccessToken = accessToken,
            Id = user.Id,
            Username = user.UserName
        };
    }
}