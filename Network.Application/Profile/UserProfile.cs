using Network.Application.App.Users.Commands;
using Network.Application.App.Users.Queries;
using Network.Application.App.Users.Request;
using Network.Application.App.Users.Response;
using Network.Domain.Models;

namespace Network.Application.Profile;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<User, UserTitleDto>();
        CreateMap<User, UserDto>();
        CreateMap<User, UserSearchDto>();
        
        CreateMap<GetCurrentUserQuery, User>();
        CreateMap<GetUserByUsernameQuery, User>();

        CreateMap<GetSearchUsersByUsernameCommand, string>();

        CreateMap<PostFollowUserCommand, FollowDto>();
        
        CreateMap<DeleteAvatarUserCommand, string>();
    }
}