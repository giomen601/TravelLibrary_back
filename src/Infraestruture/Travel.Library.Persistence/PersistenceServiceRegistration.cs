using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Persistence.DbContext;
using Travel.Library.Persistence.Repositories;

namespace Travel.Library.Persistence;
public static class PersistenceServiceRegistration
{
  public static IServiceCollection
  AddPersistenceService
  (
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    services.AddDbContext<TravelDbContext>
    (
      options => 
      {
        options.UseSqlServer(configuration.GetConnectionString("TravelDbConnectionString"));
      }
    );

    //Add Generic Repository
    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<IAuthorRepository, AuthorRepository>();
    services.AddScoped<IBookRepository, BookRepository>();
    services.AddScoped<IPublisherRepository, PublisherRepository>();

    return services;
  }
}