using Travel.Library.Application.Models.Identity;

namespace Travel.Library.Application.Contracts.Identity;
public interface IUserService
{
  Task<List<User>> GetUsers();
  Task<User> GetUser(string userId);
  public string UserId { get; }
}