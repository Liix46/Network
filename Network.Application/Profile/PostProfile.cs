using Network.Application.App.Post.Command;
using Network.Application.App.Post.Response;
using Network.Domain;

namespace Network.Application.Profile;

public class PostProfile : AutoMapper.Profile
{
    protected PostProfile()
    {
        CreateMap<Post, CreatePostDto>();
        CreateMap<Post, DeletePostDto>();
        CreateMap<Post, UpdatePostDto>();
        
        CreateMap<CreatePostCommand, Post>();
        CreateMap<DeletePostCommand, Post>();
        CreateMap<UpdatePostCommand, Post>();
    }
}