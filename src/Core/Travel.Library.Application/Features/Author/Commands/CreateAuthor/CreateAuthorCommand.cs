using MediatR;

namespace Travel.Library.Application.Features.Author.Commands.CreateAuthor;
public class CreateAuthorCommand : IRequest<int>
{
  public string? Name { get; set; }
  public string? Lastname { get; set; }
}