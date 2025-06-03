using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities; 

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        //readonly List<Employee> employees =
        //[
        //    new Employee()
        //{
        //    Id = 562,
        //    Name = "Anders Hejlsberg",
        //    Email = "Anders.Hejlsberg@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 62,
        //    Name = "Kathleen Dollard",
        //    Email = "k.d@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 15662,
        //    Name = "Mads Torgersen",
        //    Email = "Admin.Torgersen@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 52,
        //    Name = "Scott Hanselman",
        //    Email = "s.h@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 563,
        //    Name = "Jon Skeet",
        //    Email = "j.s@outlook.com",
        //},
        //];

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges(); // Inte glömma!
        }

        //Classic C# syntax for GetAll()
        public Employee[] GetAll() => [.. context.Employees];

        public Employee? GetById(int id) => context.Employees
            .Find(id);
    }
}