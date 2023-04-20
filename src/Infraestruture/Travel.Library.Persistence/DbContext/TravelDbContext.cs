using Microsoft.EntityFrameworkCore;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Persistence.DbContext;
public class TravelDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
    {
      
    }

  public DbSet<Author> Authors { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Publishers> Publishers { get; set; }
  public DbSet<AuthorBook> AuthorsBooks { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<AuthorBook>()
    .HasKey(AB => new {AB.AuthorsId, AB.BookId});
  }
}