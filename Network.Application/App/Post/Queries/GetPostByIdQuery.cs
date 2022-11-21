using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Queries;

public class GetPostByIdQuery : IRequest<GetPostByIdDto>
{
    public int PostId { get; set; }
}

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdDto>
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public GetPostByIdQueryHandler(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GetPostByIdDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _repository.GetByIdWithInclude<Domain.Models.Post>(request.PostId,
            post => post.Comments, post=> post.Likes);

        var postDto = _mapper.Map<GetPostByIdDto>(post);
        return postDto;
    }
    
    
}