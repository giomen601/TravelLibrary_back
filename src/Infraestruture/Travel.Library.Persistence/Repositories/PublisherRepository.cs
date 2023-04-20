using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Domain.Entities;
using Travel.Library.Persistence.DbContext;

namespace Travel.Library.Persistence.Repositories;
public class PublisherRepository : GenericRepository<Publishers>, IPublisherRepository
{
  public PublisherRepository(TravelDbContext context) : base(context)
  {
  }
}