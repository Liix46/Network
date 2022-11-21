using AutoMapper;
using FluentValidation;
using MediatR;
using Network.Application.App.Post.Response;
using Network.Application.Common.Interfaces.Repositories;
using Network.Domain.Models;

namespace Network.Application.App.Post.Command;

public class CreatePostCommand : IRequest<CreatePostDto>
{
    public string? description { get; set; }
    public DateTime datePublication { get; set; }
    public int userId { get; set; }
}

public class CreatePostValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.description)
            .NotNull()
            .Length(0, 500);
        RuleFor(x => x.userId)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.datePublication)
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
        var post = _mapper.Map<Domain.Models.Post>(request);
        await _repository.AddAsync(post);
        
        await _repository.SaveChangesAsync();

        var postDto = _mapper.Map<CreatePostDto>(post);
        return postDto;
    }
}