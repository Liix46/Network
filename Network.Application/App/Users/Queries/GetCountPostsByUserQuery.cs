using MediatR;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;

public class GetCountPostsByUserQuery : IRequest<int?>
{
    public string Username { get; set; }
}

public class GetCountPostsByUserQueryHandler : IRequestHandler<GetCountPostsByUserQuery, int?>
{
    private readonly IUserRepository _repository;

    public GetCountPostsByUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int?> Handle(GetCountPostsByUserQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCountPosts(request.Username);
    }
}