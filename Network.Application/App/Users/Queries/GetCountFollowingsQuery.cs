using MediatR;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;

public class GetCountFollowingsQuery : IRequest<int?>
{
    public string Username { get; set; }
}

public class GetCountFollowingsQueryHandler : IRequestHandler<GetCountFollowingsQuery, int?>
{
    private readonly IUserRepository _repository;

    public GetCountFollowingsQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int?> Handle(GetCountFollowingsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCountFollowing(request.Username);
    }
}