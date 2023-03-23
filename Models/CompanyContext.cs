using Microsoft.EntityFrameworkCore;

namespace MvcEFApp.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
