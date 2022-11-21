using AutoMapper;
using MediatR;
using Network.Application.App.Images.Response;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;

namespace Network.Application.App.Images.Command;

public class CreateImageCommand : IRequest<CreateImageDto>
{
    public string? Name { get; set; }
    public string? Url { get;set;}
    public string? FormatType { get; set; }
    public int PostId { get; set; }
}

public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, CreateImageDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public CreateImageCommandHandler(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var image = _mapper.Map<Image>(request);
        image.FormatType = image.FormatType.Substring(image.FormatType.IndexOf('/')+1);
        image.Url += '.' + image.FormatType;
        await _repository.AddAsync(image);
        await _repository.SaveChangesAsync();
        
        return _mapper.Map<CreateImageDto>(image);
    }
}