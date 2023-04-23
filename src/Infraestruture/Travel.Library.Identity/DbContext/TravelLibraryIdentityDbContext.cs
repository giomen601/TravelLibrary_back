using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel.Library.Identity.Models;

namespace Travel.Library.Identity.DbContext;
public class TravelLibraryIdentityDbContext : IdentityDbContext<ApplicationUser>
{
  public TravelLibraryIdentityDbContext
  (
    DbContextOptions<TravelLibraryIdentityDbContext> options
  ) : base(options)
  {
    
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly
    (typeof(TravelLibraryIdentityDbContext).Assembly);
  }
}