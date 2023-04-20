using MediatR;

namespace Travel.Library.Application.Features.Publisher.Commands.UpdatePublisher;
public class UpdatePublisherCommand : IRequest<Unit>
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? HouseLocation { get; set; }
}