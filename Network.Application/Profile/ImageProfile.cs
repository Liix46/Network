using System.Net.Mime;
using Network.Application.App.Images.Command;
using Network.Application.App.Images.Response;
using Network.Application.App.Users.Response;
using Network.Domain.Models;

namespace Network.Application.Profile;

public class ImageProfile : AutoMapper.Profile
{
    public ImageProfile()
    {
        CreateMap<Image, CreateImageDto>();
        
        CreateMap<CreateImageCommand, Image>();

        CreateMap<Image, ImageDto>();
        
    }
    
    
}