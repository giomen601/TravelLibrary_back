using AutoMapper;
using Travel.Library.Application.Features.Publisher.Commands.CreatePublisher;
using Travel.Library.Application.Features.Publisher.Commands.UpdatePublisher;
using Travel.Library.Application.Features.Publisher.Queries.GetAllPublishers;
using Travel.Library.Application.Features.Publisher.Queries.GetPublisherDetail;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Application.MappingProfile;
public class PublisherProfile : Profile
{
  public PublisherProfile()
  {
    CreateMap<PublisherDto, Publishers>().ReverseMap();
    CreateMap<PublisherDetailDto, Publishers>().ReverseMap();
    CreateMap<CreatePublisherCommand, Publishers>();
    CreateMap<UpdatePublisherCommand, Publishers>();
  }
}