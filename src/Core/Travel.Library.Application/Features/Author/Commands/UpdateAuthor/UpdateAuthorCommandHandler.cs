using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Author.Commands.UpdateAuthor;
public class UpdateAuthorCommandHandler :
IRequestHandler<UpdateAuthorCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly IAuthorRepository authorRepository;

  public UpdateAuthorCommandHandler
  (
    IMapper mapper,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.authorRepository = authorRepository;
  }
  public async Task<Unit> Handle
  (
    UpdateAuthorCommand request,
    CancellationToken cancellationToken
  )
  {
    //Validate errors
    var validator = new UpdateAuthorCommandValidator(authorRepository);
    var validationResult = await validator.ValidateAsync(request);

    if(validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid Author", validationResult);
    }

    var author = await authorRepository.GetByIdAsync(request.Id);

    if(author is null)
    {
      throw new NotFoundException(nameof(Author), request.Id);
    }

    mapper.Map(request, author);

    await authorRepository.UpdateAsync(author);
    return Unit.Value;
  }
}