using Travel.Library.Domain.Entities;

namespace Travel.Library.Application.Contracts.Persistence;
public interface IBookRepository : IGenericRepository<Book>
{
  Task<List<Book>> GetBookWithDetails();
  Task<Book> GetBookWithDetails(int id);

}