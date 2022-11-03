using AutoMapper;
using MediatR;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain;

namespace Network.Application.App.Post.Command;

public class UpdatePostCommand : IRequest
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public List<Image>? Images { get; set; }
}

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private IMapper _mapper;
    private IRepository _repository;

    public UpdatePostCommandHandler(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _repository.GetById<Domain.Post>(request.Id);
        _mapper.Map(request, post);
        await _repository.SaveChangesAsync();
        
        return Unit.Value;
    }
}