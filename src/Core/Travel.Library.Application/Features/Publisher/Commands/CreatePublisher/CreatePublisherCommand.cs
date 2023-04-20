using MediatR;

namespace Travel.Library.Application.Features.Publisher.Commands.CreatePublisher;
public class CreatePublisherCommand : IRequest<Unit>
{
  public string? Name { get; set; }
  public string? HouseLocation { get; set; }
}