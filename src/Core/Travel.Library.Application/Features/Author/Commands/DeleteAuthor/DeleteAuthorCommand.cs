using MediatR;

namespace Travel.Library.Application.Features.Author.Commands.DeleteAuthor;
public class DeleteAuthorCommand : IRequest<Unit>
{
    public int Id { get; set; }
}