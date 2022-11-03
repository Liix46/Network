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
    public async Task<GetByIdPostDto> GetPost(int id)
    {
        var postDto = await _mediator.Send(new GetPostByIdQuery() {PostId = id});
        return postDto;
    }

    [HttpPatch("{id}")]
    public async Task UpdatePost(UpdatePostCommand updatePostCommand)
    {
        await _mediator.Send(updatePostCommand);
    }
    
}