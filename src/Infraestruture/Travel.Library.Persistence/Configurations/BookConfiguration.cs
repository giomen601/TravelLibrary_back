using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Persistence.Configurations;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
  public void Configure
  (
    EntityTypeBuilder<Book> builder
  )
  {
    builder.HasData
    (
      new Book
      {
        Id = 1,
        Title = "First book",
        Synopsis = "First book test synopsis",
        PublishersId = 1,
      },
      new Book
      {
        Id = 2,
        Title = "Second book",
        Synopsis = "Second book test synopsis",
        PublishersId = 3,
      }
    );
  }
}