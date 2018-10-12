using AuthServer.Data.Models;
using AuthServer.Data.Persistence;
using AuthServer.Exceptions;

namespace AuthServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public bool IsUserExists(string UserId)
        {
            var user = _repo.FindUserById(UserId);
            if(user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Login(string UserId, string Password)
        {
            var user= _repo.Login(UserId,Password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("Invalid user id or password");
            }
        }

        public User RegisterUser(User UserDetails)
        {
            var user = _repo.Register(UserDetails);
            return user;
        }
    }
}
