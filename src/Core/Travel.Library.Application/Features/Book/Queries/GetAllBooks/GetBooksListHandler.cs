using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Book.Queries.GetAllBooks;
public class GetBooksListHandler :
IRequestHandler<GetBooksListQuery, List<BookDto>>
{
  private readonly IMapper mapper;
  private readonly IBookRepository bookRepository;

  public GetBooksListHandler
  (
    IMapper mapper,
    IBookRepository bookRepository
  )
  {
    this.mapper = mapper;
    this.bookRepository = bookRepository;
  }

  public async Task<List<BookDto>> Handle
  (
    GetBooksListQuery request,
    CancellationToken cancellationToken
  )
  {
    //var books = await bookRepository.GetAsync();
    var books = await bookRepository.GetBookWithDetails();
    var data = mapper.Map<List<BookDto>>(books);

    return data;
  }
}