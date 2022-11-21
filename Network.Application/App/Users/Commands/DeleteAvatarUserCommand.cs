using MediatR;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Commands;

public class DeleteAvatarUserCommand : IRequest<bool>
{
    public string Username { get; set; }
}

public class DeleteAvatarUserCommandHandler : IRequestHandler<DeleteAvatarUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteAvatarUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteAvatarUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.RemoveAvatarImage(request.Username);
        return true;
    }
}