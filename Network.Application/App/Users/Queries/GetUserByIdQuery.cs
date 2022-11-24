using AutoMapper;
using MediatR;
using Network.Application.App.Users.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int UserId { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.UserId);
        return _mapper.Map<UserDto>(user);
    }
}