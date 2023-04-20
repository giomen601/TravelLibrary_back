using MediatR;

namespace Travel.Library.Application.Features.Book.Commands.DeleteBook;
public class DeleteBookCommand : IRequest<Unit>
{
  public int Id { get; set; }
}