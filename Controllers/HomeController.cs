using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcEFApp.Models;
using System.Diagnostics;

namespace MvcEFApp.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext companyContext;
        public HomeController(CompanyContext companyContext)
        {
            this.companyContext = companyContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await companyContext.Employees.ToListAsync());
        }

        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserAdd(Employee employee)
        {
            companyContext.Employees.Add(employee);
            await companyContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}