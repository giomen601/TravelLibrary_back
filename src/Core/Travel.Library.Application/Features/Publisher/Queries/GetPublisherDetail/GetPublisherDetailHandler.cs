using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Publisher.Queries.GetPublisherDetail;
public class GetPublisherDetailHandler :
IRequestHandler<GetPublisherDetailQuery, PublisherDetailDto>
{
  private readonly IMapper mapper;
  private readonly IPublisherRepository publisherRepository;

  public GetPublisherDetailHandler
  (
    IMapper mapper,
    IPublisherRepository publisherRepository
  )
  {
    this.mapper = mapper;
    this.publisherRepository = publisherRepository;
  }

  public async Task<PublisherDetailDto> Handle
  (
    GetPublisherDetailQuery request,
    CancellationToken cancellationToken
  )
  {
    var publisher = await publisherRepository.GetByIdAsync(request.Id);
    return mapper.Map<PublisherDetailDto>(publisher);
  }
}