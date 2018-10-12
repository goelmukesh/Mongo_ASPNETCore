using AuthServer.Data.Models;

namespace AuthServer.Services
{
    public interface IUserService
    {
        bool IsUserExists(string UserId);
        User  RegisterUser(User user);
        User Login(string UserId, string Password);
    }
}
