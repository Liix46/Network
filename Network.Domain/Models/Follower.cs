namespace Network.Domain.Models;

public class Follower : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
}