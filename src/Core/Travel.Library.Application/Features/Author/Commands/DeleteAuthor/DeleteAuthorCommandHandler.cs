using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Author.Commands.DeleteAuthor;
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
  private readonly IAuthorRepository authorRepository;

  public DeleteAuthorCommandHandler
  (
    IAuthorRepository authorRepository
  )
  {
    this.authorRepository = authorRepository;
  }
  public async Task<Unit> Handle
  (
    DeleteAuthorCommand request,
    CancellationToken cancellationToken
  )
  {
    //transform to domain entity object
    var authorToDelete = await authorRepository.GetByIdAsync(request.Id);

    //variify if that record exist
    if(authorToDelete == null)
    {
      throw new NotFoundException(nameof(Author), request.Id);
    }

    //remove from data base
    await authorRepository.DeleteAsync(authorToDelete);

    //return record id
    return Unit.Value;
  }
}