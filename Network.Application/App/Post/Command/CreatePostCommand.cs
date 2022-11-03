using AutoMapper;
using FluentValidation;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain;

namespace Network.Application.App.Post.Command;

public class CreatePostCommand : IRequest<CreatePostDto>
{
    public string? Description { get; set; }
    public DateTime DatePublication { get; set; }
    public int UserId { get; set; }
    public List<Image>? Images { get; set; }
}

public class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .Length(0, 500);
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.DatePublication)
            .NotEmpty();
    }
}

public class CreatePostCommandHandle : IRequestHandler<CreatePostCommand, CreatePostDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public CreatePostCommandHandle(IMapper mapper, IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreatePostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Domain.Post>(request);
        _repository.Add(post);
        return _mapper.Map<CreatePostDto>(post);
    }
}