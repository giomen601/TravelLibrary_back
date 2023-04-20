using MediatR;

namespace Travel.Library.Application.Features.Book.Queries.GetBookDetail;
public class GetBookDetailQuery : IRequest<BookDetailDto>
{
    public int Id { get; set; }
}