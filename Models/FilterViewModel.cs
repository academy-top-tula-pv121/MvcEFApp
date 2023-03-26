using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcEFApp.Models
{
    public class FilterViewModel
    {
        public SelectList Companies { get; }
        public int SelectedCompany { get; }
        public string SelectedName { get; }
        public FilterViewModel(List<Company> companies, int selectedCompany, string selectedName)
        {
            companies.Insert(0, new Company() { Id = 0, Title = "All companies" });
            Companies = new SelectList(companies, "Id", "Title", selectedCompany);
            SelectedCompany = selectedCompany;
            SelectedName = selectedName;
        }
    }
}
