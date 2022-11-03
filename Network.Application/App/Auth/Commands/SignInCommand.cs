using MediatR;
using Network.Application.App.Auth.Responses;
using Network.Application.Common.Interfaces;

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

    public SignInCommandHandler(IAuthenticationService authenticationService, ITokenService tokenService)
    {
        _authenticationService = authenticationService;
        _tokenService = tokenService;
    }
    public async Task<SingInDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var passwordSignInResult = request.Password != null && request.UserName != null && await _authenticationService.PasswordSignInAsync(request.UserName, request.Password);
        string? accessToken = null;
        if (passwordSignInResult)
        {
            accessToken = _tokenService.GenerateAccessToken();
        }

        return new SingInDto()
        {
            Succeeded = passwordSignInResult,
            AccessToken = accessToken
        };
    }
}