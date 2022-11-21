using System.Runtime.Serialization.Formatters;
using Network.Domain.Models;
using Network.Infrastructure.Persistance.Contexts;

namespace Network.Infrastructure.Persistance.DataSeed.SeedModels;

public static class ImageSeed
{
    public static async Task Seed(NetworkDbContext networkDbContext)
    {
        if (!networkDbContext.Images.Any())
        {
            var image = new Image()
            {
                PostId = 1,
                FormatType = "jpeg",
                Name = "36c95edb-af53-6479-d19a-73263c88be13",
                Url = "uploads/Liix46/36c95edb-af53-6479-d19a-73263c88be13.jpeg"
            };
            var image2 = new Image()
            {
                PostId = 2,
                FormatType = "jpeg",
                Name = "8cfef2bc-acd0-a846-518f-6fb8c8b66a6a",
                Url = "uploads/Liix46/8cfef2bc-acd0-a846-518f-6fb8c8b66a6a.jpeg"
            };
            var image3 = new Image()
            {
                PostId = 3,
                FormatType = "jpeg",
                Name = "f74b1a23-0e7d-1877-6888-0fc7e98bfd9a",
                Url = "uploads/Liix46/f74b1a23-0e7d-1877-6888-0fc7e98bfd9a.jpeg"
            };
            var image4 = new Image()
            {
                PostId = 4,
                FormatType = "jpeg",
                Name = "043ef207-de7a-d189-0183-44808e9ed99d",
                Url = "uploads/Liix46/043ef207-de7a-d189-0183-44808e9ed99d.jpeg"
            };
            var image5 = new Image()
            {
                PostId = 5,
                FormatType = "png",
                Name = "e1e3aab0-2b27-0e89-3ef2-ad439017879a",
                Url = "uploads/Liix46/e1e3aab0-2b27-0e89-3ef2-ad439017879a.png"
            };
            var image6 = new Image()
            {
                PostId = 6,
                FormatType = "jpeg",
                Name = "fba3971f-8a12-b6ef-40cf-9cd4f23037e8",
                Url = "uploads/therock/fba3971f-8a12-b6ef-40cf-9cd4f23037e8.jpeg"
            };
            var image7 = new Image()
            {
                PostId = 7,
                FormatType = "jpeg",
                Name = "7ae06bb4-1630-3a71-a65e-6f8077f13d56",
                Url = "uploads/therock/7ae06bb4-1630-3a71-a65e-6f8077f13d56.jpeg"
            };
            var image8 = new Image()
            {
                PostId = 8,
                FormatType = "jpeg",
                Name = "be9dc801-da50-3d09-1419-200c5465a0a4",
                Url = "uploads/therock/be9dc801-da50-3d09-1419-200c5465a0a4.jpeg"
            };

            networkDbContext.Images.Add(image);
            networkDbContext.Images.Add(image2);
            networkDbContext.Images.Add(image3);
            networkDbContext.Images.Add(image4);
            networkDbContext.Images.Add(image5);
            networkDbContext.Images.Add(image6);
            networkDbContext.Images.Add(image7);
            networkDbContext.Images.Add(image8);
            await networkDbContext.SaveChangesAsync();
        }
    }
}