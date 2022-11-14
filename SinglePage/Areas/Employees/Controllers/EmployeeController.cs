using Microsoft.AspNetCore.Mvc;
using SinglePage.Areas.Employees.Data;
using SinglePage.Areas.Employees.Models;
using SinglePage.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePage.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repo = null;
        public EmployeeController(EmployeeRepository repo)
        {
            _repo = repo;
        }
       
        public async Task<IActionResult> Index()
        {
            VmEmployee data = new VmEmployee()
            {
                employees = await _repo.GetEmployee()
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] VmEmployee model)
        {
            string filename = "";
            if (model.Image != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture");
                FileInfo info = new FileInfo(model.Image.FileName);
                string newfilename = DateTime.Now.ToString("yyyymmddhhmmss");
                filename = newfilename + info.Extension;
                string filewithpath = Path.Combine(path, filename);
                using (var stream = new FileStream(filewithpath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
            }
            Employee data = new Employee()
            {
                Id = model.Id,
                employeeCode = model.employeeCode,
                employeeName = model.employeeName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Image = filename,
            };
            await _repo.SaveEmployee(data);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.ToDelete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> checkcode(string code)
        {
            var c = await _repo.checkCode(code);
            return Json(c);
        }

    }
}
