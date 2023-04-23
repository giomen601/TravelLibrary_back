using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Persistence.Configurations;
public class PublisherConfiguration : IEntityTypeConfiguration<Publishers>
{
  public void Configure
  (
    EntityTypeBuilder<Publishers> builder
  )
  {
    builder.HasData
    (
      new Publishers
      {
        Id = 1,
        Name = "First publisher",
        HouseLocation = "Location test one"
      },
      new Publishers
      {
        Id = 2,
        Name = "Second publisher test",
        HouseLocation = "Location test two"
      },
      new Publishers
      {
        Id = 3,
        Name = "Third publisher test",
        HouseLocation = "Location test three"
      }
    );
  }
}