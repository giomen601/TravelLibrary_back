using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Travel.Library.Application.Contracts.Identity;
using Travel.Library.Application.Models.Identity;
using Travel.Library.Identity.DbContext;
using Travel.Library.Identity.Models;
using Travel.Library.Identity.Services;

namespace Travel.Library.Identity;
public static class IdentityServicesRegistration
{
  public static IServiceCollection AddIdentityServices
  (
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    
    services.AddDbContext<TravelLibraryIdentityDbContext>
    (
      options =>
      options.UseSqlServer(configuration.GetConnectionString("TravelDbConnectionString"))
    );

    services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TravelLibraryIdentityDbContext>()
    .AddDefaultTokenProviders();

    services.AddTransient<IAuthService, AuthService>();
    services.AddTransient<IUserService, UserServices>();

    services.AddAuthentication
    (
      options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }
    )
    .AddJwtBearer
    (
      x => 
      {
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          ValidIssuer = configuration["JwtSettings:Issuer"],
          ValidAudience = configuration["JwtSettings:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey
          (Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        };
      }
    );

    return services;
  }
}