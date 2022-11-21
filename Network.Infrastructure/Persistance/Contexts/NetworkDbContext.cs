using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Network.Domain.Models;
using Network.Domain.Auth;
using Network.Infrastructure.Persistance.Constants;

namespace Network.Infrastructure.Persistance.Contexts;

public class NetworkDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public NetworkDbContext(DbContextOptions<NetworkDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);            
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Following> Followings { get; set; }
    public DbSet<Follower> Followers { get; set; }
    
    private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
        modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
        modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
        modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConstants.Auth);
        modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
        modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
        modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
    }
}