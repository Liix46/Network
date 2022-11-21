using MediatR;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Commands;

public class PostFollowUserCommand : IRequest<bool>
{
    public string usernameFrom { get; set; }
    public string usernameTo { get; set; }
}

public class PostFollowUserCommandHandler : IRequestHandler<PostFollowUserCommand, bool>
{
    private readonly IUserRepository _repository;

    public PostFollowUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(PostFollowUserCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddFollowing(request.usernameFrom, request.usernameTo);
    }
}