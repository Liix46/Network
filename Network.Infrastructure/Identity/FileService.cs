using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Network.Application.Common.Interfaces;

namespace Network.Infrastructure.Identity;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FileService( IWebHostEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor )
    {
        _hostingEnvironment = hostingEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> SaveFile(string path)
    {
        var request = _httpContextAccessor.HttpContext.Request;
        if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
        {
            _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }
        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);
        var isExistsDirectory = Directory.Exists(uploads);
        if (!isExistsDirectory)
        {
            Directory.CreateDirectory(uploads);
        }
        
        var file = request.Form.Files.FirstOrDefault();
        var filePath = Path.Combine(uploads, file.FileName +'.'+ file.ContentType.Substring(file.ContentType.IndexOf('/')+1));
        
        using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
            await file.CopyToAsync(fileStream);
        }

        return filePath;
    }
}