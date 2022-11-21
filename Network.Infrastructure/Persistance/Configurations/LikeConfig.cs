using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Network.Domain.Models;

namespace Network.Infrastructure.Persistance.Configurations;

public class LikeConfig : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasOne(l => l.User).WithMany(u => u.Likes).OnDelete(DeleteBehavior.Cascade);
        // builder.HasOne(l => l.Post).WithMany(post => post.Likes).OnDelete(DeleteBehavior.Cascade);
    }
}