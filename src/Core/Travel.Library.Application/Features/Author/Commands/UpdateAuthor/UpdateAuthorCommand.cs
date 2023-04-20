using MediatR;

namespace Travel.Library.Application.Features.Author.Commands.UpdateAuthor;
public class UpdateAuthorCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
}