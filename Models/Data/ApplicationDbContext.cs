using Api_Test.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Test.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
