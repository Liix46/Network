using AutoMapper;
using MediatR;
using Network.Application.App.Comments.Response;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;

namespace Network.Application.App.Comments.Commands;

public class CreateCommentCommand : IRequest<CommentDto>
{
    public DateTime DatePublication { get; set; }
    public string? Text { get; set; }
    public int? PostId { get; set; }
    public int? UserId { get; set; }
}

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public CreateCommentCommandHandler(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request);
        //comment.DatePublication = DateTime.Now;
        
        await _repository.AddAsync(comment);
        
        await _repository.SaveChangesAsync();

        var commentUser = await _repository.GetByIdWithInclude<Comment>(comment.Id, comment1 => comment1.User);
        var commentDto = _mapper.Map<CommentDto>(commentUser);
        return commentDto;
    }
}
