using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Publisher.Queries.GetAllPublishers;
public class GetPublisherListHandler :
IRequestHandler<GetPublisherListQuery, List<PublisherDto>>
{
  private readonly IMapper mapper;
  private readonly IPublisherRepository publisherRepository;

  public GetPublisherListHandler
  (
    IMapper mapper,
    IPublisherRepository publisherRepository
  )
  {
    this.mapper = mapper;
    this.publisherRepository = publisherRepository;
  }

  public async Task<List<PublisherDto>> Handle
  (
    GetPublisherListQuery request,
    CancellationToken cancellationToken
  )
  {
    var publisher = await publisherRepository.GetAsync();
    var data = mapper.Map<List<PublisherDto>>(publisher);

    return data;
  }
}