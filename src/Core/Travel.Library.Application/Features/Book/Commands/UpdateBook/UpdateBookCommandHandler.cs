using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Book.Commands.UpdateBook;
public class UpdateBookCommandHandler
: IRequestHandler<UpdateBookCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly IBookRepository bookRepository;
  private readonly IAuthorRepository authorRepository;

  public UpdateBookCommandHandler
  (
    IMapper mapper,
    IBookRepository bookRepository,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.bookRepository = bookRepository;
    this.authorRepository = authorRepository;
  }
  public async Task<Unit> Handle
  (
    UpdateBookCommand request,
    CancellationToken cancellationToken
  )
  {
    //Validate incoming data
    var validator = new UpdateBookCommandValidator(authorRepository, bookRepository);
    var validationResult = await validator.ValidateAsync(request);

    if(validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid book", validationResult);
    }

    var book = await bookRepository.GetByIdAsync(request.Id);

    mapper.Map(request, book);

    await bookRepository.UpdateAsync(book);
    return Unit.Value;
  }
}