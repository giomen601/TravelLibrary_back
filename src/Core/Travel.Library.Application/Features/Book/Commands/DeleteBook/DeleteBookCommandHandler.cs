using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Book.Commands.DeleteBook;
public class DeleteBookCommandHandler :
IRequestHandler<DeleteBookCommand>
{
  private readonly IMapper mapper;
  private readonly IBookRepository bookRepository;

  public DeleteBookCommandHandler
  (
    IMapper mapper,
    IBookRepository bookRepository
  )
  {
    this.mapper = mapper;
    this.bookRepository = bookRepository;
  }

  public async Task<Unit> Handle
  (
    DeleteBookCommand request,
    CancellationToken cancellationToken
  )
  {
    var book = await bookRepository.GetByIdAsync(request.Id);

    if(book == null)
    {
      throw new NotFoundException(nameof(book), request.Id);
    }

    await bookRepository.DeleteAsync(book);
    return Unit.Value;
  }
}