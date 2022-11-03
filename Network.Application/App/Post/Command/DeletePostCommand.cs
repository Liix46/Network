using AutoMapper;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;

namespace Network.Application.App.Post.Command;

public class DeletePostCommand : IRequest<DeletePostDto>
{
    public int Id { get; set; }
}

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletePostDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public DeletePostCommandHandler(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DeletePostDto> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<DeletePostDto>(_repository.Delete<Domain.Post>(request.Id));
    }
}