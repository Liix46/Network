namespace Network.Domain.Models;

public class Following : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
}