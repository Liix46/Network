using Network.Application.App.Comments.Commands;
using Network.Application.App.Comments.Response;
using Network.Domain.Models;

namespace Network.Application.Profile;

public class CommentProfile : AutoMapper.Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>();
        
        CreateMap<CreateCommentCommand, Comment>();
    }
}