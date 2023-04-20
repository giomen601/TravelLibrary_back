using MediatR;

namespace Travel.Library.Application.Features.Book.Commands.UpdateBook;
public class UpdateBookCommand : IRequest<Unit>
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Synopsis { get; set; }
  public int PublisherId { get; set; }
  public List<int>? AuthorsId { get; set; }
}