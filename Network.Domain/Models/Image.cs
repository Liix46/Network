using System.Text.Json.Serialization;

namespace Network.Domain.Models;

public class Image : BaseEntity
{
    public string? Name { get; set; }
    public string? Url { get;set;}
    public string? FormatType { get; set; }
    
    //one
    public int PostId { get; set; }
    [JsonIgnore]
    public Post Post { get; set; }
}