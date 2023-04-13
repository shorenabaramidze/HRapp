using HRapplication.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace HRapplication.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

}
