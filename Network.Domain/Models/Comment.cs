
using System.Text.Json.Serialization;

namespace Network.Domain.Models;

public class Comment : BaseEntity
{
    public DateTime DatePublication { get; set; }
    public string? Text { get; set; } // до 500 символов
    
    public int PostId { get; set; }
    [JsonIgnore]
    public Post Post { get; set; }
    
    public int? UserId { get; set; }
    //[JsonIgnore]
    public User? User { get; set; }
}