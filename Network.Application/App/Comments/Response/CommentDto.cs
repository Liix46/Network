using Network.Domain.Models;

namespace Network.Application.App.Comments.Response;

public class CommentDto
{
    public DateTime DatePublication { get; set; }
    public string? Text { get; set; } // до 500 символов
    
    public int PostId { get; set; }
    public Domain.Models.Post Post { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
}