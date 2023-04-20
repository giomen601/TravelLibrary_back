using Microsoft.EntityFrameworkCore;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Domain.Entities;
using Travel.Library.Persistence.DbContext;

namespace Travel.Library.Persistence.Repositories;
public class BookRepository : GenericRepository<Book>, IBookRepository
{
  public BookRepository(TravelDbContext context) : base(context)
  {
  }

  public async Task<List<Book>> GetBookWithDetails()
  {
    var bookRequest = await context.Books
    .Include(x => x.AuthorsBooks)
    .ThenInclude(y => y.Authors)
    .Include(x => x.Publishers)
    .ToListAsync();
    return bookRequest;
  }

  public Task<Book> GetBookWithDetails(int id)
  {
    throw new NotImplementedException();
  }
}