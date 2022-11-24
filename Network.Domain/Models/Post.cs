using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Network.Domain.Models;

public class Post : BaseEntity
{
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    
    //many
    public ICollection<Comment>? Comments { get; set; }
    
    public Image? Image { get; set; }
    public ICollection<Like>? Likes { get; set; }
    
    //one
    public int UserId { get; set; }
    public User User { get; set; }
}