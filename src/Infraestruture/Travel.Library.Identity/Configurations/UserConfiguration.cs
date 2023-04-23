using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel.Library.Identity.Models;

namespace Travel.Library.Identity.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
  public void Configure
  (
    EntityTypeBuilder<ApplicationUser> builder
  )
  {
    var hasher = new PasswordHasher<ApplicationUser>();

    builder.HasData
    (
      new ApplicationUser
      {
        Id = "9f63609b-808b-412c-93ed-6aab06cce828",
        Email = "admin@localhost.com",
        NormalizedEmail = "ADMIN@LOCALHOST.COM",
        UserName = "admin@localhost.com",
        NormalizedUserName = "ADMIN@LOCALHOST.COM",
        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
        EmailConfirmed = true
      }
    );
  }
}