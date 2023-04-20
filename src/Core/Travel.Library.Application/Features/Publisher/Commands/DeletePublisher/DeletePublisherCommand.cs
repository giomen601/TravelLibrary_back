using MediatR;

namespace Travel.Library.Application.Features.Publisher.Commands.DeletePublisher;
public class DeletePublisherCommand : IRequest<Unit>
{
  public int Id { get; set; }
}