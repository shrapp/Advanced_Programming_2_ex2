using Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; } 
    }
}