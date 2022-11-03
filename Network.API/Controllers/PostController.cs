using MediatR;
using Microsoft.AspNetCore.Mvc;
using Network.Application.App.Post.Command;
using Network.Application.App.Post.Queries;
using Network.Application.App.Post.Response;

namespace Network.API.Controllers;

[Route("api/posts")]
public class PostController : AppBaseController
{
    public PostController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<CreatePostDto> CreatePost(CreatePostCommand createPostCommand)
    {
        var postDto = await _mediator.Send(createPostCommand);
        return postDto;
    }

    [HttpDelete("{id}")]
    public async Task<DeletePostDto> DeletePost(int id)
    {
        var deleteDto = await _mediator.Send(new DeletePostCommand() {Id = id});
        return deleteDto;
    }

    [HttpGet("{id}")]
    public async Task<GetPostByIdDto> GetPost(int id)
    {
        var postDto = await _mediator.Send(new GetPostByIdQuery() {PostId = id});
        return postDto;
    }

    [HttpGet("{userId}")]
    public async Task<IEnumerable<GetPostByFieldDto>> GetPostsByUserId(int userId)
    {
        var posts = await _mediator
            .Send(new GetPostsByUserIdQuery() {UserId = userId});
        return posts;
    }

    [HttpGet("{username}")]
    public async Task<IEnumerable<GetPostByFieldDto>> GetPostsByUsername(string username)
    {
        var posts = await _mediator
            .Send(new GetPostsByUsernameQuery() {Username = username});
        return posts;
    }


    [HttpPatch("{id}")]
    public async Task UpdatePost(UpdatePostCommand updatePostCommand)
    {
        await _mediator.Send(updatePostCommand);
    }
    
}