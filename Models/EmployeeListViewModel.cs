using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcEFApp.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set;} = new List<Employee>();
        public SelectList Companies { set; get; } = new SelectList(new List<Company>(), "Id", "Title");
        public string? EmployeeName { set; get; }
    }
}
