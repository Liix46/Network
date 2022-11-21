using Network.Domain.Models;

namespace Network.Application.App.Post.Response;

public class UpdatePostDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public List<Image>? Images { get; set; }
}