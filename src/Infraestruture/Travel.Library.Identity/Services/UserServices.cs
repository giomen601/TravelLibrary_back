using Travel.Library.Application.Contracts.Identity;
using Travel.Library.Application.Models.Identity;

namespace Travel.Library.Identity.Services;
public class UserServices : IUserService
{
  public string UserId => throw new NotImplementedException();

  public Task<User> GetUser(string userId)
  {
    throw new NotImplementedException();
  }

  public Task<List<User>> GetUsers()
  {
    throw new NotImplementedException();
  }
}