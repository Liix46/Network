using MediatR;
using Microsoft.EntityFrameworkCore;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Queries;

public class GetPostByFollowingsQuery : IRequest<IEnumerable<Domain.Models.Post>>
{
    public string Username { get; set; }
    public int Start { get; set; }
}

public class GetPostByFollowingsQueryHandler : IRequestHandler<GetPostByFollowingsQuery, IEnumerable<Domain.Models.Post>>
{
    private readonly IUserRepository _userRepository;
    private readonly IRepository _repository;

    public GetPostByFollowingsQueryHandler(IUserRepository userRepository, IRepository repository)
    {
        _userRepository = userRepository;
        _repository = repository;
    }

    public async Task<IEnumerable<Domain.Models.Post>> Handle(GetPostByFollowingsQuery request, CancellationToken cancellationToken)
    {
        var followings = await _userRepository.GetFollowings();
        var user = await followings.FirstOrDefaultAsync(u => u.UserName == request.Username, cancellationToken: cancellationToken);

        var idFollowings = user.Followings.Select(following => following.FollowingId).ToList();

        var posts = await _repository.GetAllWithInclude<Domain.Models.Post>(post => post.Image, post => post.Comments,
            post => post.Likes, post => post.User);

        var filterPosts = posts.Where(p => idFollowings.Contains(p.UserId));

        var orderPosts = filterPosts.OrderByDescending(p => p.DatePublication).Skip(request.Start).Take(10);

        return orderPosts;
    }
}