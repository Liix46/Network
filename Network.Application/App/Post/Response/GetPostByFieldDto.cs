using Network.Domain.Models;

namespace Network.Application.App.Post.Response;

public class GetPostByFieldDto
{
    public int Id { get; set; }
    public DateTime DatePublication { get; set; }
    
    public List<Comment>? Comments { get; set; }
    public List<Image>? Images { get; set; }
    public List<Like>? Likes { get; set; }
    
    public int UserId { get; set; }
}