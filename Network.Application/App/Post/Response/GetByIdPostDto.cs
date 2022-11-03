using Network.Domain;

namespace Network.Application.App.Post.Response;

public class GetByIdPostDto
{
    public int Id { get; set; }
    public DateTime DatePublication { get; set; }
    public int Likes { get; set; }
    
    public List<Comment>? Comments { get; set; }
    public List<Image>? Images { get; set; }
    
    public int UserId { get; set; }
}