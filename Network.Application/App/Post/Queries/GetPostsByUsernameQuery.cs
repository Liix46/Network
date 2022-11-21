using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Queries;

public class GetPostsByUsernameQuery : IRequest<IEnumerable<GetPostByFieldDto>>
{
    public string? Username { get; set; }
}

public class GetPostsByUsernameQueryHandler : IRequestHandler<GetPostsByUsernameQuery, IEnumerable<GetPostByFieldDto>>
{
    private readonly IRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPostsByUsernameQueryHandler(IRepository repository, IMapper mapper, IUserRepository userRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetPostByFieldDto>> Handle(GetPostsByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsername(request.Username);
        var postsDto = _mapper.Map<List<GetPostByFieldDto>>(user.Posts)
            .Where(post => post.UserId == user.Id);
        
        return postsDto;
    }
}