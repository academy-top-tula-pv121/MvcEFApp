namespace MvcEFApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; } 
            = new List<Employee>();
        public SortViewModel SortViewModel { set; get; } 
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { set; get; }
        public IndexViewModel(IEnumerable<Employee> employees,
                                            SortViewModel sortViewModel,
                                            FilterViewModel filterViewModel,
                                            PageViewModel pageViewModel)
        {
            Employees = employees;
            PageViewModel = pageViewModel;
            SortViewModel = sortViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
