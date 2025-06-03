namespace EmployeesApp.Domain.Entities;
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Employee> Employees { get; set; } = null!;
}
