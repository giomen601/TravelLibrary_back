using MediatR;

namespace Travel.Library.Application.Features.Book.Queries.GetAllBooks;
public record GetBooksListQuery : IRequest<List<BookDto>>;