using Microsoft.EntityFrameworkCore;

namespace MvcEFApp.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
