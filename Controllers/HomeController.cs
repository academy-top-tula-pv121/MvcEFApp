using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcEFApp.Models;

namespace MvcEFApp.Controllers
{
    public class HomeController : Controller
    {
        CompanyContext context;

        public HomeController(CompanyContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(string name, 
                                                int companyId, 
                                                int page = 1, 
                                                SortProp sortOrder = SortProp.NameAsc)
        {
            int pageSize = 3;

            // filters
            IQueryable<Employee> employees = context.Employees
                                                    .Include(e => e.Company);
            if(companyId != 0)
                employees = employees.Where(e => e.CompanyId == companyId);
            if (!String.IsNullOrEmpty(name))
                employees = employees.Where(e => e.Name!.Contains(name));

            // sorts
            switch (sortOrder)
            {
                case SortProp.NameDesc:
                    employees = employees.OrderByDescending(e => e.Name);
                    break;
                case SortProp.BirthDateAsc:
                    employees = employees.OrderBy(e => e.BirthDate);
                    break;
                case SortProp.BirthDateDesc:
                    employees = employees.OrderByDescending(e => e.BirthDate);
                    break;
                case SortProp.CompanyAsc:
                    employees = employees.OrderBy(e => e.Company!.Title);
                    break;
                case SortProp.CompanyDesc:
                    employees = employees.OrderByDescending(e => e.Company!.Title);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Name);
                    break;
            }

            // paging
            var countTotal = await employees.CountAsync();
            var emplyesPage = await employees.Skip((page - 1) * pageSize)
                                             .Take(pageSize)
                                             .ToListAsync();

            IndexViewModel viewModel = new(
                emplyesPage,
                new SortViewModel(sortOrder),
                new FilterViewModel(context.Companies.ToList(), companyId, name),
                new PageViewModel(countTotal, page, pageSize)
                );


            return View(viewModel);
        }
    }
}
