using Microsoft.EntityFrameworkCore;

namespace CRUDDemo.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }


        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }
    }
}
