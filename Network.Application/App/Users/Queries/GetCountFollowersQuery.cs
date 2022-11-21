using MediatR;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;

public class GetCountFollowersQuery : IRequest<int?>
{
    public string Username { get; set; }
}

public class GetCountFollowersQueryHandler : IRequestHandler<GetCountFollowersQuery, int?>
{
    private readonly IUserRepository _repository;

    public GetCountFollowersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int?> Handle(GetCountFollowersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCountFollowers(request.Username);
    }
}