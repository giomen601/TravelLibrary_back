using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Publisher.Commands.DeletePublisher;
public class DeletePublisherCommandHandler :
IRequestHandler<DeletePublisherCommand>
{
  private readonly IMapper mapper;
  private readonly IPublisherRepository publisherRepository;

  public DeletePublisherCommandHandler
  (
    IMapper mapper,
    IPublisherRepository publisherRepository
  )
  {
    this.mapper = mapper;
    this.publisherRepository = publisherRepository;
  }

  public async Task<Unit> Handle
  (
    DeletePublisherCommand request,
    CancellationToken cancellationToken
  )
  {
    var publisher = await publisherRepository.GetByIdAsync(request.Id);

    if(publisher == null)
      throw new NotFoundException(nameof(publisher), request.Id);

      await publisherRepository.DeleteAsync(publisher);
      return Unit.Value;
  }
}