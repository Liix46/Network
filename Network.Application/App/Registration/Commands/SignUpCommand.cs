using MediatR;
using Network.Application.App.Registration.Responses;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;

namespace Network.Application.App.Registration.Commands;

public class SignUpCommand : IRequest<SignUpDto>
{
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpDto>
{
    private readonly IRegistrationService _registrationService;
    private readonly IAuthenticationService _authenticationService;
    private readonly ITokenService _tokenService;

    public SignUpCommandHandler(IRegistrationService registrationService, IAuthenticationService authenticationService, ITokenService tokenService)
    {
        _registrationService = registrationService;
        _authenticationService = authenticationService;
        _tokenService = tokenService;
    }

    public async Task<SignUpDto> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = request.FullName,
            UserName = request.UserName,
            Email = request.Email,
            
        };

        if (request.Password == null) throw new ArgumentNullException();
        
        var result = await _registrationService.CreateAsync(user, request.Password);


        if (!result) throw new Exception("User not created");
        if (user.UserName == null) throw new ArgumentNullException();
        
        var passwordSignInResult = await _authenticationService.PasswordSignInAsync(user.UserName, request.Password);
            
        string? accessToken = null;
        if (passwordSignInResult)
        {
            accessToken = _tokenService.GenerateAccessToken(user);
        }

        return new SignUpDto()
        {
            AccessToken = accessToken,
            Succeeded = passwordSignInResult,
            Id = user.Id,
            Username = user.UserName
        };
    }
}