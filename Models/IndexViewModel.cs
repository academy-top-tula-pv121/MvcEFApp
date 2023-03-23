namespace MvcEFApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; } 
            = new List<Employee>();
        public SortViewModel SortViewModel { set; get; } 
            = new SortViewModel(SortProp.NameAsc);
    }
}
