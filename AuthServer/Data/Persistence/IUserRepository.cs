using AuthServer.Data.Models;

namespace AuthServer.Data.Persistence
{
    public interface IUserRepository
    {
        User FindUserById(string UserId);
        User Register(User user);
        User Login(string userId, string password);
    }
}
