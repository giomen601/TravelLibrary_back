using Microsoft.EntityFrameworkCore;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Domain.Common;
using Travel.Library.Persistence.DbContext;

namespace Travel.Library.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
  protected readonly TravelDbContext context;

  public GenericRepository(TravelDbContext context)
  {
    this.context = context;
  }

  public async Task<T> CreateAsync(T entity)
  {
    await context.AddAsync(entity);
    await context.SaveChangesAsync();
    return entity;
  }

  public async Task<T> DeleteAsync(T entity)
  {
    context.Remove(entity);
    await context.SaveChangesAsync();
    return entity;
  }

  public async Task<IReadOnlyList<T>> GetAsync()
  {
    return await context.Set<T>().AsNoTracking().ToListAsync();
  }

  public async Task<T> GetByIdAsync(int id)
  {
    return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<T> UpdateAsync(T entity)
  {
    context.Entry(entity).State = EntityState.Modified;
    await context.SaveChangesAsync();
    return entity;
  }
}