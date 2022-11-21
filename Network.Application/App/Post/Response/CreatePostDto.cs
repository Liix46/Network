using Network.Domain;

namespace Network.Application.App.Post.Response;

public class CreatePostDto
{
    public int? Id { get; set; }
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    public int UserId { get; set; }
}