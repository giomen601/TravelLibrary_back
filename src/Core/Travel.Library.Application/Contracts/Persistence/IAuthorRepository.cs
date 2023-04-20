using Travel.Library.Domain.Entities;

namespace Travel.Library.Application.Contracts.Persistence;
public interface IAuthorRepository : IGenericRepository<Author>
{
  Task<List<Author>> GetAuthorWithDetails();
  Task<Author> GetAuthorWithDetails(int id);
}