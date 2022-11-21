using AutoMapper;
using MediatR;
using Network.Application.App.Users.Response;
using Network.Application.Common.Interfaces;

namespace Network.Application.App.Users.Queries;

public class GetCurrentUserQuery : IRequest<UserTitleDto>
{
    
}

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserTitleDto>
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly IMapper _mapper;

    public GetCurrentUserQueryHandler(IUserIdentityService userIdentityService, IMapper mapper)
    {
        _userIdentityService = userIdentityService;
        _mapper = mapper;
    }

    public async Task<UserTitleDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
         var user = await _userIdentityService.GetCurrentUser();
         var userDto = _mapper.Map<UserTitleDto>(user);
         return userDto;

    }
}