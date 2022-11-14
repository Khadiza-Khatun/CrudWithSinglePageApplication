using Microsoft.EntityFrameworkCore;
using SinglePage.Areas.Employees.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePage.DB
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> option) : base(option)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
