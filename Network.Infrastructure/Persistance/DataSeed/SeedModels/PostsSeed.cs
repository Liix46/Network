using Network.Domain;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Persistance.DataSeed.SeedModels;

public class PostsSeed
{
    public static async Task Seed(NetworkDbContext networkDbContext)
    {
        if (!networkDbContext.Posts.Any())
        {
            var post = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "It`s my first post!",
                UserId = 1
            };

            networkDbContext.Posts.Add(post);

            await networkDbContext.SaveChangesAsync();
        }
    }
}