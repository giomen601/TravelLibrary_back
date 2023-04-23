using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Library.Identity.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
  public void Configure
  (
    EntityTypeBuilder<IdentityRole> builder
  )
  {
    builder.HasData
    (
      new IdentityRole
      {
        Id = "424ff644-105d-4a7b-be7c-1fe7e33ea4a9",
        Name = "Administrator",
        NormalizedName = "ADMINISTRATOR"
      }
    );
  }
}