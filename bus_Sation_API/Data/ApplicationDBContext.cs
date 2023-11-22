using bus_Sation_API.Models;
using Microsoft.EntityFrameworkCore;

namespace bus_Sation_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
