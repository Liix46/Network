namespace Network.Domain;

public class Post : BaseEntity
{
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    
    //many
    public List<Comment>? Comments { get; set; }
    public List<Image>? Images { get; set; }
    public List<Like>? Likes { get; set; }
    
    //one
    public int UserId { get; set; }
    public User? User { get; set; }
}