using MediatR;
using Network.Application.App.Users.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Commands;

public class GetSearchUsersByUsernameCommand : IRequest<IEnumerable<UserSearchDto>>
{
    public string SearchString { get; set; }
}

public class GetSearchUsersByUsernameCommandHandler 
    : IRequestHandler<GetSearchUsersByUsernameCommand, IEnumerable<UserSearchDto>>
{
    private readonly IUserRepository _repository;

    public GetSearchUsersByUsernameCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserSearchDto>> Handle(GetSearchUsersByUsernameCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetSearchUsersByUsername(request.SearchString);
    }
}