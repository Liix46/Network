using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Network.Domain.Models;

namespace Network.Infrastructure.Persistance.Configurations;

public class PostConfig : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .OnDelete(DeleteBehavior.Cascade);
        

        builder.HasOne(p => p.Image)
            .WithOne(i => i.Post)
            .HasForeignKey<Image>(i => i.PostId);
        
    }
}