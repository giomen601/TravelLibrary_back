using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Publisher.Commands.UpdatePublisher;
public class UpdatePublisherCommandHandler :
IRequestHandler<UpdatePublisherCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly IPublisherRepository publisherRepository;

  public UpdatePublisherCommandHandler
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
    UpdatePublisherCommand request,
    CancellationToken cancellationToken
  )
  {
    var validator = new UpdatePublisherCommandValidator();
    var validationResult = await validator.ValidateAsync(request);

    if(validationResult.Errors.Any())
      throw new BadRequestException("Invalid Publisher", validationResult);

    var publisher = await publisherRepository.GetByIdAsync(request.Id);

    if(publisher is null)
      throw new NotFoundException(nameof(publisher), request.Id);

    mapper.Map(request, publisher);
    return Unit.Value;
  }
}