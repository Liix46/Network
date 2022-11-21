using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Queries;

public class GetPostsByUserIdQuery : IRequest<IEnumerable<GetPostByFieldDto>>
{
    public int UserId { get; set; }
}

public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, IEnumerable<GetPostByFieldDto>>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public GetPostsByUserIdQueryHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetPostByFieldDto>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var postList = await _repository.GetAllWithInclude<Domain.Models.Post>(post => post.Comments, post => post.Likes);
        var sortedPostDtoList = _mapper.Map<List<GetPostByFieldDto>>(postList)
            .Where(post => post.UserId == request.UserId);
        return sortedPostDtoList;
    }
}