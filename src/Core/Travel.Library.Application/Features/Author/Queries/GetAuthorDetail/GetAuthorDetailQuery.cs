using MediatR;

namespace Travel.Library.Application.Features.Author.Queries.GetAuthorDetail;
public class GetAuthorDetailQuery : IRequest<AuthorDetailDto>
{
  public int Id { get; set; }
}