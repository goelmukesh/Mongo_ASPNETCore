using System.Linq;
using AuthServer.Data.Models;
using AuthServer.Exceptions;

namespace AuthServer.Data.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDbContext _context;
        public UserRepository(IUserDbContext context)
        {
            _context = context;
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(string userId, string password)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == userId && u.Password == password);
            return _user;
        }

        public User FindUserById(string UserId)
        {
            var _user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            return _user;
        }
    }
}
