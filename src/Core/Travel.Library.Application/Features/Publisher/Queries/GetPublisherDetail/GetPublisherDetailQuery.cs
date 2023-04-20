using MediatR;

namespace Travel.Library.Application.Features.Publisher.Queries.GetPublisherDetail;
public class GetPublisherDetailQuery : IRequest<PublisherDetailDto>
{
    public int Id { get; set; }
}