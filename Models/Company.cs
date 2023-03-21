namespace MvcEFApp.Models
{
    public class Company
    {
        public int Id { set; get; }
        public string? Title { set; get; }
        public List<Employee> Employees { set; get; } = new();
    }
}