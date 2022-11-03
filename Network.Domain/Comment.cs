namespace Network.Domain;

public class Comment : BaseEntity
{
    public DateTime DatePublication { get; set; }
    public string? Text { get; set; } // до 500 символов
    
    public int PostId { get; set; }
    public Post? Post { get; set; }
}