//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using MvcEFApp.Models;
//using System.Diagnostics;

//namespace MvcEFApp.Controllers
//{
//    public class HomeControllerOld : Controller
//    {
//        CompanyContext companyContext;
//        public HomeControllerOld(CompanyContext companyContext)
//        {
//            this.companyContext = companyContext;

//            //Company[] companies = new[]{
//            //    new Company(){ Title = "Yandex" },
//            //    new Company(){ Title = "Ozon" },
//            //    new Company(){ Title = "Mail Group" },
//            //    new Company(){ Title = "Rambler" },
//            //};

//            //companyContext.Companies.AddRange(companies);

//            //companyContext.Employees.AddRange(new []{
//            //    new Employee() { Name = "Joe", BirthDate = new DateTime(2002, 05, 23), Company = companies[0] },
//            //    new Employee() { Name = "Tom", BirthDate = new DateTime(1999, 01, 1), Company = companies[1] },
//            //    new Employee() { Name = "Sam", BirthDate = new DateTime(1997, 11, 15), Company = companies[2] },
//            //    new Employee() { Name = "Bob", BirthDate = new DateTime(2001, 02, 6), Company = companies[3] },
//            //    new Employee() { Name = "Tim", BirthDate = new DateTime(1999, 09, 9), Company = companies[0] },
//            //    new Employee() { Name = "Jim", BirthDate = new DateTime(2000, 12, 18), Company = companies[1] },
//            //    new Employee() { Name = "Leo", BirthDate = new DateTime(1980, 07, 22), Company = companies[2] },
//            //    new Employee() { Name = "Paul", BirthDate = new DateTime(2002, 07, 3), Company = companies[3] },
//            //    new Employee() { Name = "Nill", BirthDate = new DateTime(1998, 03, 19), Company = companies[0] },
//            //});

//            //companyContext.SaveChanges();

//        }

//        //, SortProp sortProp = SortProp.NameAsc
//        // int? companyId, string? employeeName
//        public async Task<IActionResult> Index(int page = 1)
//        {
//            int pageSize = 3;

//            IQueryable<Employee> employees = companyContext.Employees.Include(e => e.Company);

//            int count = await employees.CountAsync();
//            var employeesPage = await employees.Skip((page - 1) * pageSize)
//                                                .Take(pageSize)
//                                                .ToListAsync();

//            PageViewModel pageViewModel = new(count, page, pageSize);
//            IndexViewModel viewModel = new(employeesPage, pageViewModel);


//            //if (companyId is not null && companyId != 0)
//            //    employees = employees.Where(e => e.CompanyId == companyId);
//            //if(!String.IsNullOrWhiteSpace(employeeName))
//            //    employees = employees.Where(e => e.Name!.Contains(employeeName));

//            //List<Company> companies = companyContext.Companies.ToList();
//            //companies.Insert(0, new Company() { Id = 0, Title = "All companies" });

//            //ViewData["NameSort"] = sortProp == SortProp.NameAsc ? SortProp.NameDesc : SortProp.NameAsc;
//            //ViewData["BirthDateSort"] = sortProp == SortProp.BirthDateAsc ? SortProp.BirthDateDesc : SortProp.BirthDateAsc;
//            //ViewData["CompanySort"] = sortProp == SortProp.CompanyAsc ? SortProp.CompanyDesc : SortProp.CompanyAsc;

//            //ViewBag.NameSort = sortProp == SortProp.NameAsc ? SortProp.NameDesc : SortProp.NameAsc;
//            //ViewBag.BirthDateSort = sortProp == SortProp.BirthDateAsc ? SortProp.BirthDateDesc : SortProp.BirthDateAsc;
//            //ViewBag.CompanySort = sortProp == SortProp.CompanyAsc ? SortProp.CompanyDesc : SortProp.CompanyAsc;

//            //employees = sortProp switch
//            //{
//            //    SortProp.NameDesc => employees.OrderByDescending(e => e.Name),
//            //    SortProp.BirthDateAsc => employees.OrderBy(e => e.BirthDate),
//            //    SortProp.BirthDateDesc => employees.OrderByDescending(e => e.BirthDate),
//            //    SortProp.CompanyAsc => employees.OrderBy(e => e.Company!.Title),
//            //    SortProp.CompanyDesc => employees.OrderByDescending(e => e.Company!.Title),
//            //    _ => employees.OrderBy(e => e.Name),
//            //};

//            //IndexViewModel viewModel = new IndexViewModel()
//            //{
//            //    Employees = await employees.ToListAsync(),
//            //    SortViewModel = new SortViewModel(sortProp)
//            //};

//            //EmployeeListViewModel viewModel = new EmployeeListViewModel()
//            //{
//            //    Employees = employees.ToList(),
//            //    Companies = new SelectList(companies, "Id", "Title", companyId),
//            //    EmployeeName = employeeName
//            //};

//            return View(viewModel);
//        }

//        public IActionResult UserAdd()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> UserAdd(Employee employee)
//        {
//            companyContext.Employees.Add(employee);
//            await companyContext.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if(id is not null)
//            {
//                /*
//                Employee? employee = await companyContext.Employees
//                                                        .FirstOrDefaultAsync(e => e.Id == id);
//                if(employee is not null)
//                {
//                    companyContext.Employees.Remove(employee);
//                    await companyContext.SaveChangesAsync();
//                    return RedirectToAction("Index");
//                }
//                */
//                Employee? employee = new Employee(){ Id = id.Value };
//                companyContext.Entry(employee).State = EntityState.Deleted;
//                await companyContext.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return NotFound();
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if(id is not null)
//            {
//                Employee? employee = await companyContext.Employees
//                                                .FirstOrDefaultAsync(e => e.Id == id);
//                if(employee is not null)
//                    return View(employee);
//            }
//            return NotFound();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(Employee employee)
//        {
//            companyContext.Employees.Update(employee);
//            await companyContext.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}