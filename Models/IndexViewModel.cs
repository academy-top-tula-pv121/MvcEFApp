namespace MvcEFApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; } 
            = new List<Employee>();
        //public SortViewModel SortViewModel { set; get; } 
        //    = new SortViewModel(SortProp.NameAsc);
        public PageViewModel PageViewModel { get; set; }
        public IndexViewModel(IEnumerable<Employee> employees, PageViewModel pageViewModel)
        {
            Employees = employees;
            PageViewModel = pageViewModel;
        }
    }
}
