using AutoMapper;
using MediatR;
using Network.Application.App.Users.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Users.Queries;

public class GetUserImagesQuery : IRequest<IEnumerable<ImageDto>>
{
    public string Username { get; set; }
}

public class GetUserImagesQueryHandler : IRequestHandler<GetUserImagesQuery, IEnumerable<ImageDto>>
{
    private readonly IUserRepository _repository;

    public GetUserImagesQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ImageDto>> Handle(GetUserImagesQuery request, CancellationToken cancellationToken)
    {
        
        return await _repository.GetUserImages(request.Username);
    }
}