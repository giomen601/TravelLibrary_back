using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Persistence.Configurations;
public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
{
  public void Configure
  (
    EntityTypeBuilder<AuthorBook> builder
  )
  {
    builder.HasData
    (
      new AuthorBook
      {
        AuthorsId = 1,
        BookId = 1
      },
      new AuthorBook
      {
        AuthorsId = 2,
        BookId = 1
      },
      new AuthorBook
      {
        AuthorsId = 2,
        BookId = 2
      }
    );
  }
}