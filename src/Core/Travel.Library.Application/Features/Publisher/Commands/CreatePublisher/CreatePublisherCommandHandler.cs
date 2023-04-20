using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Exceptions;

namespace Travel.Library.Application.Features.Publisher.Commands.CreatePublisher;
public class CreatePublisherCommandHandler :
IRequestHandler<CreatePublisherCommand, Unit>
{
  private readonly IMapper mapper;
  private readonly IPublisherRepository publisherRepository;

  public CreatePublisherCommandHandler
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
    CreatePublisherCommand request,
    CancellationToken cancellationToken
  )
  {
    var validation = new CreatePublisherCommandValidator(publisherRepository);
    var validationResult = await validation.ValidateAsync(request);

    if(validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid publisher", validationResult);
    }

    var publisherToCreate = mapper.Map<Domain.Entities.Publishers>(request);

    await publisherRepository.CreateAsync(publisherToCreate);

    return Unit.Value;
  }
}