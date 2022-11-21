using MediatR;
using Network.Application.Common.Interfaces;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Files.Command;

public class SaveFileCommand : IRequest<string?>
{
    public string Username { get; init; }
    public string PathMainDirectory { get; init; } = "";
}

public class SaveFileCommandHandler : IRequestHandler<SaveFileCommand, string?>
{
    private readonly IFileService _fileService;
    private readonly IUserRepository _repository;

    public SaveFileCommandHandler(IFileService fileService, IUserRepository repository)
    {
        _fileService = fileService;
        _repository = repository;
    }
    public async Task<string?> Handle(SaveFileCommand request, CancellationToken cancellationToken)
    {
        
        var path = "uploads/" + request.Username + '/' + request.PathMainDirectory;
        
        
        path = await _fileService.SaveFile(path);
        if (request.PathMainDirectory.Trim().Length <= 0) return path;
        
        var user = await _repository.GetByUsername(request.Username);
        user.UrlMainImage = path.Substring(path.IndexOf("uploads"));
        _repository.SaveChangesAsync();
        return path;
    }
}