using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Library.Identity.Configurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
  public void Configure
  (
    EntityTypeBuilder<IdentityUserRole<string>> builder
  )
  {
    builder.HasData
    (
      new IdentityUserRole<string>
      {
        RoleId = "424ff644-105d-4a7b-be7c-1fe7e33ea4a9",
        UserId = "9f63609b-808b-412c-93ed-6aab06cce828"
      }
    );
  }
}