namespace Network.Domain.Models;

public class Like : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
}