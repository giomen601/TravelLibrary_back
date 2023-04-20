using Microsoft.EntityFrameworkCore;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Domain.Entities;
using Travel.Library.Persistence.DbContext;

namespace Travel.Library.Persistence.Repositories;
public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
  public AuthorRepository(TravelDbContext context) : base(context)
  {
  }

  public async Task<List<Author>> GetAuthorWithDetails()
  {
    var authorRequest = await context.Authors
    .Include(x => x.AuthorsBooks)
    .ThenInclude(y => y.Books)
    .ToListAsync();
    return authorRequest;
  }

  public Task<Author> GetAuthorWithDetails(int id)
  {
    throw new NotImplementedException();
  }
}