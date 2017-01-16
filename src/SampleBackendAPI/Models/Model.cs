using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SampleBackendAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
    }

}
