using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePage.Areas.Employees.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string employeeCode { get; set; }
        public string employeeName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Image { get; set; }
      
    }
}
