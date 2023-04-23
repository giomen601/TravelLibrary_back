using Microsoft.AspNetCore.Mvc;
using Travel.Library.Application.Contracts.Identity;
using Travel.Library.Application.Models.Identity;

namespace Travel.Library.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService authService;

  public AuthController
  (
    IAuthService authService
  )
  {
    this.authService = authService;
  }

  [HttpPost("login")]
  public async Task<ActionResult<AuthResponse>>
  Login(AuthRequest request)
  {
    return Ok(await authService.Login(request));
  }

  [HttpPost("register")]
  public async Task<ActionResult<RegistrationResponse>>
  Register(RegistrationRequest request)
  {
    return Ok(await authService.Register(request));
  }
}