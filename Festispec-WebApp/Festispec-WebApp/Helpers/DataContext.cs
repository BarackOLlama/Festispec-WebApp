using Festispec_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Festispec_WebApp.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<FSContext> options) : base(options) { }
 
    }
}