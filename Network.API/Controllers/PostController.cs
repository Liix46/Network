using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Network.Application.App.Files.Command;
using Network.Application.App.Images.Command;
using Network.Application.App.Images.Response;
using Network.Application.App.Post.Command;
using Network.Application.App.Post.Queries;
using Network.Application.App.Post.Response;
using Network.Domain.Models;

namespace Network.API.Controllers;

[Route("api/posts")]
public class PostController : AppBaseController
{
    public PostController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePost(CreatePostCommand createPostCommand)
    {
        var postDto = await _mediator.Send(createPostCommand);
        return Ok(postDto);
    }

    [HttpPost("images")]
    public async Task<IActionResult> SaveImage(CreateImageCommand createImageCommand)
    {
        var imageDto = await _mediator.Send(createImageCommand);
        return Ok(imageDto);
    }
    
    [HttpPost("uploads/{username}")]
    public async Task<IActionResult> SaveFile(string username)
    {
        try
        {
            await _mediator.Send(new SaveFileCommand(){Username = username});
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPost("uploads/avatar/{username}")]
    public async Task<IActionResult> SaveAvatarImage(string username)
    {
        try
        {
            var url = await _mediator.Send(new SaveFileCommand()
            {
                Username = username,
                PathMainDirectory = "avatars"
            });
            return Ok(url);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>  DeletePost(int id)
    {
        var deleteDto = await _mediator.Send(new DeletePostCommand() {Id = id});
        return Ok(deleteDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>  GetPost(int id)
    {
        var postDto = await _mediator.Send(new GetPostByIdQuery() {PostId = id});
        return Ok(postDto);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult>  GetPostsByUserId(int userId)
    {
        var posts = await _mediator
            .Send(new GetPostsByUserIdQuery() {UserId = userId});
        return Ok(posts);
    }

    [HttpGet("{username}")]
    public async Task<IActionResult>  GetPostsByUsername(string username)
    {
        var posts = await _mediator
            .Send(new GetPostsByUsernameQuery() {Username = username});
        return Ok(posts);
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult>  UpdatePost(UpdatePostCommand updatePostCommand)
    {
        await _mediator.Send(updatePostCommand);
        return new OkResult();
    }
    
    
}