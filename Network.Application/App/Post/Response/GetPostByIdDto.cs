using System.Text.Json.Serialization;
using Network.Domain.Models;

namespace Network.Application.App.Post.Response;

public class GetPostByIdDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    public Image? Image { get; set; }
    [JsonInclude]
    public List<Comment>? Comments { get; set; }
    public List<Like>? Likes { get; set; }
}