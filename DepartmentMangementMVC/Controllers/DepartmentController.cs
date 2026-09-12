using DepartmentMangementMVC.Data;
using DepartmentMangementMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentMangementMVC.Controllers
{
    public class DepartmentController : Controller
    {
        
        
        public IActionResult Index()
        {
          ApplicationDbContext context = new ApplicationDbContext();
             var departments = context.Departments.Include(x=>x.Employees).ToList();
            var departmentViewModels = departments.Select(d => new DepartmentViewModel
            {
                DepartmentId = d.Id,
                DepartmentName = d.Name,
                ManagerName = d.ManagerName,
                EmployeeCount = d.Employees.Count
            }).ToList();
            ViewData["Number"] = 100;

            ViewData["Message"] = "Welcome to Departments";

            ViewData["Names"] = new List<string>
{
    "Ahmed",
    "Sara",
    "Omar"
};

            ViewBag.Number = 200;

            ViewBag.Message = "Hello from ViewBag";

            ViewBag.Names = new List<string>
{
    "Mona",
    "Ali",
    "Youssef"
};
            return View(departmentViewModels);
        }
    }
}
