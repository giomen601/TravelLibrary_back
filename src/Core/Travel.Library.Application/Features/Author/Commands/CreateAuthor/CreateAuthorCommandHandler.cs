using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Author.Commands.CreateAuthor;
public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
  private readonly IMapper mapper;
  private readonly IAuthorRepository authorRepository;

  public CreateAuthorCommandHandler
  (
    IMapper mapper,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.authorRepository = authorRepository;
  }
  public async Task<int> Handle
  (
    CreateAuthorCommand request,
    CancellationToken cancellationToken
  )
  {
    //Validate incoming data
    var validator = new CreateAuthorCommandValidator(authorRepository);
    var validatorResult = await validator.ValidateAsync(request);

    if(validatorResult.Errors.Any())
    {
      throw new BadRequestException("Invalid Author", validatorResult);
    }

    //convert to domain entity type object
    var authorToCreate = mapper.Map<Domain.Entities.Author>(request);

    //add to data base
    await authorRepository.CreateAsync(authorToCreate);

    return authorToCreate.Id;
  }
}