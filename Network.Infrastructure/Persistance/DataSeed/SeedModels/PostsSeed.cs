using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Persistance.DataSeed.SeedModels;

public static class PostsSeed
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
            var post2 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "this is my 2 post!!!",
                UserId = 1
            };
            var post3 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "t th thi this this i this is  this is t this is to this is tow",
                UserId = 1
            };
            var post4 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "Create The Impossible",
                UserId = 1
            };
            var post5 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "life it`s life 😂",
                UserId = 1
            };
            
            var post6 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "That’s a Saturday wrap.  Another ones bites the dust in the #ironparadise 💪🏾🙏🏾🏋🏾‍♀️   Feelin’ Macho in my “Ohhhh Yeah” shades 👓 (Savage was always my dream match as it would’ve been an honor to share the squared circle with him 🕊️)",
                UserId = 2
            };
            var post7 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "Teth Adam rose from a slave to champion to the Man in Black⚡️  The physical transformation to become Black Adam⚡️ was one of the most grueling, intense & demanding commitments of my entire career - including football and wrestling.   I worked very close with my long time & trusted strength and conditioning coach @daverienzi who created the year long roadmap for us to execute.   Health, wellness, balance, diet, discipline & iron.   And Black Adam LOVES his cheat meals 🤣",
                UserId = 2
            };
            var post8 = new Post()
            {
                DatePublication = DateTime.Now,
                Description = "No greater connection. Our MANA.  Powerful.  Grateful.  Love U back 🤟🏾",
                UserId = 2
            };
            networkDbContext.Posts.Add(post);
            networkDbContext.Posts.Add(post2);
            networkDbContext.Posts.Add(post3);
            networkDbContext.Posts.Add(post4);
            networkDbContext.Posts.Add(post5);
            networkDbContext.Posts.Add(post6);
            networkDbContext.Posts.Add(post7);
            networkDbContext.Posts.Add(post8);
            
            await networkDbContext.SaveChangesAsync();
        }
    }
}