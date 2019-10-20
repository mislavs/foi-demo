using FoiDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoiDemo.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}
