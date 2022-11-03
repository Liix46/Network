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
    private readonly IMapper _mapper;

    public GetPostsByUsernameQueryHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetPostByFieldDto>> Handle(GetPostsByUsernameQuery request, CancellationToken cancellationToken)
    {
        var postList = await _repository.GetAllWithInclude<Domain.Post>(post => post.Comments, post => post.Images, post => post.Likes);
        var sortedPostDtoList = _mapper.Map<List<GetPostByFieldDto>>(postList)
            .Where(post => post.User.UserName == request.Username);
        
        return sortedPostDtoList;
    }
}