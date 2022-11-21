using AutoMapper;
using MediatR;
using Network.Application.App.Users.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;



public class GetUserByUsernameQuery : IRequest<UserDto>
{
    public string Username { get; set; }
}

public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserByUsernameQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByUsername(request.Username);
        return _mapper.Map<UserDto>(user);
    }
}