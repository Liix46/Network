using MediatR;
using Network.Application.Common.Interfaces;

namespace Network.Application.App.Auth.Commands;

public class SignOutCommand: IRequest
{
    
}

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly ISignOutService _signOutService;

    public SignOutCommandHandler(ISignOutService signOutService)
    {
        _signOutService = signOutService;
    }

    public async Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _signOutService.SignOut();
        return Unit.Value;
    }
}