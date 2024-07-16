using Crud_App_ASP_NETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudApp_Asp.net_Core.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpDbContext context;

        public EmployeeController(EmpDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await context.EmpTbs.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(EmpTb addEmployeeRequest)
        {
            var employee = new EmpTb()
            {
                EmpName = addEmployeeRequest.EmpName,
                Age = addEmployeeRequest.Age,
                Designation = addEmployeeRequest.Designation,
                Salary = addEmployeeRequest.Salary
            };
            await context.EmpTbs.AddAsync(employee);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await context.EmpTbs.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmpTb editEmployeeRequest)
        {
            var employee = await context.EmpTbs.FindAsync(editEmployeeRequest.EmpId);
            if (employee == null)
            {
                return NotFound();
            }

            employee.EmpName = editEmployeeRequest.EmpName;
            employee.Age = editEmployeeRequest.Age;
            employee.Designation = editEmployeeRequest.Designation;
            employee.Salary = editEmployeeRequest.Salary;

            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await context.EmpTbs.FindAsync(id);
            if (employee != null)
            {
                context.EmpTbs.Remove(employee);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
