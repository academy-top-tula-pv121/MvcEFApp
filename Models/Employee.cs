namespace MvcEFApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public int? CompanyId {set; get;}
        public Company? Company {set; get;}
    }
}
