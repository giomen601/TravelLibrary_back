using Travel.Library.Application.Models.Identity;

namespace Travel.Library.Application.Contracts.Identity;
public interface IAuthService
{
  Task<AuthResponse> Login(AuthRequest request);
  Task<RegistrationResponse> Register(RegistrationRequest request);
}