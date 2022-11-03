using Network.Domain;

namespace Network.Application.App.Post.Response;

public class CreatePostDto
{
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    public int UserId { get; set; }
    public List<Image> Images { get; set; }
}