using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;

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
            post => post.Comments, post=> post.Likes, post=>post.Image);

        ICollection<Comment?> comments = new List<Comment?>();
        foreach (var comment in post.Comments)
        {
            comments.Add(await _repository.GetByIdWithInclude<Comment>(comment.Id, comment1 => comment1.User)); 
        }

        post.Comments = comments;
        var postDto = _mapper.Map<GetPostByIdDto>(post);
        return postDto;
    }
    
    
}