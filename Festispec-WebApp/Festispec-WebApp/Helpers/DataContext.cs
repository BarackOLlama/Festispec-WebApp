using Festispec_WebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
 
        public DbSet<User> Users { get; set; }
    }
}