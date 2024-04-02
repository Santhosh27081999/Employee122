
using Microsoft.EntityFrameworkCore;
using Practical1App.Models;

namespace Practical1App.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<EmployeeExperienceDetails> EmployeeExperienceDetails { get; set; }
    }
}
