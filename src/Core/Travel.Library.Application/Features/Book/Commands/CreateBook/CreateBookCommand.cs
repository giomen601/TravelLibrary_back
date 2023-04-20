using MediatR;

namespace Travel.Library.Application.Features.Book.Commands.CreateBook;
public class CreateBookCommand : IRequest<int>
{
  public string? Title { get; set; }
  public string? Synopsis { get; set; }
  public int PublishersId { get; set; }
  public List<int>? AuthorsId { get; set; }
}