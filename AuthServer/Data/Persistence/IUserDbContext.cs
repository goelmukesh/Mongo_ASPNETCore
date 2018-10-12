using Microsoft.EntityFrameworkCore;
using AuthServer.Data.Models;

namespace AuthServer.Data.Persistence
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
