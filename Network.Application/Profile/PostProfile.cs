using Network.Application.App.Post.Command;
using Network.Application.App.Post.Response;
using Network.Application.App.Users.Queries;
using Network.Application.App.Users.Response;
using Network.Domain.Models;

namespace Network.Application.Profile;

public class PostProfile : AutoMapper.Profile
{
    public PostProfile()
    {
        CreateMap<Post, CreatePostDto>();
        CreateMap<Post, DeletePostDto>();
        CreateMap<Post, UpdatePostDto>();
        
        CreateMap<CreatePostCommand, Post>();
        CreateMap<DeletePostCommand, Post>();
        CreateMap<UpdatePostCommand, Post>();

        
    }
}