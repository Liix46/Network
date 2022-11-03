using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Queries;

public class GetPostByIdQuery : IRequest<GetByIdPostDto>
{
    public int PostId { get; set; }
}

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetByIdPostDto>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public GetPostByIdQueryHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GetByIdPostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _repository.GetByIdWithInclude<Domain.Post>(request.PostId,
            post => post.Comments, post => post.Images, post=> post.Likes);

        var postDto = _mapper.Map<GetByIdPostDto>(post);
        return postDto;
    }
}