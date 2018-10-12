using Microsoft.EntityFrameworkCore;
using AuthServer.Data.Models;

namespace AuthServer.Data.Persistence
{
    public class UserDbContext:DbContext, IUserDbContext
    {
        public UserDbContext() { }
        public UserDbContext(DbContextOptions options) : base(options) { this.Database.EnsureCreated(); }
        public DbSet<User> Users { get; set; }
    }
}
