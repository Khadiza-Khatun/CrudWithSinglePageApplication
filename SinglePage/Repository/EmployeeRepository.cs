using Microsoft.EntityFrameworkCore;
using SinglePage.Areas.Employees.Data;
using SinglePage.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePage.Repository
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _ctx = null;
        public EmployeeRepository(EmployeeDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Employee>> GetEmployee()
        {
            return await _ctx.Employees.ToListAsync();
        }
        public async Task<int> SaveEmployee(Employee model)
        {
            if (model.Id != 0)
            {
                _ctx.Employees.Update(model);

            }
            else
            {
                _ctx.Employees.Add(model);
            }
            await _ctx.SaveChangesAsync();
            return model.Id;
        }
        public async Task<int> ToDelete(int id)
        {
            _ctx.Employees.Remove(_ctx.Employees.Find(id));
            return await _ctx.SaveChangesAsync();
        }
        public async Task<string> checkCode(string code)
        {
            var result = await _ctx.Employees.Where(x => x.employeeCode == code).Select(x => x.employeeCode).FirstOrDefaultAsync();
            if (result != null)
            {
                result = "duplicate";
                return result;
            }
            return result;
        }
    }
}

