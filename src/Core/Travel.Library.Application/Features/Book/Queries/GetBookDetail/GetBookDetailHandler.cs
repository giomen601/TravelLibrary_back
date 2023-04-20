using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Book.Queries.GetBookDetail;
public class GetBookDetailHandler :
IRequestHandler<GetBookDetailQuery, BookDetailDto>
{
  private readonly IMapper mapper;
  private readonly IBookRepository bookRepository;

  public GetBookDetailHandler
  (
    IMapper mapper,
    IBookRepository bookRepository
  )
  {
    this.mapper = mapper;
    this.bookRepository = bookRepository;
  }

  public async Task<BookDetailDto> Handle
  (
    GetBookDetailQuery request,
    CancellationToken cancellationToken
  )
  {
    var book = await bookRepository.GetByIdAsync(request.Id);
    return mapper.Map<BookDetailDto>(book); 
  }
}