using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Persistence.Configurations;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
  public void Configure
  (
    EntityTypeBuilder<Author> builder
  )
  {
    builder.HasData(
      new Author
      {
        Id = 1,
        Name = "First Name",
        Lastname = "Author One"
      },
      new Author
      {
        Id = 2,
        Name = "Second Name",
        Lastname = "Author Two"
      }
    );
  }
}