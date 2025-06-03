using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories;

public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
{
    public async Task AddAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync(); // Inte glömma!
    }

    public async Task<Employee[]> GetAllAsync() => await context.Employees.Include(e=>e.Company).AsNoTracking().ToArrayAsync();

    public async Task<Employee?> GetByIdAsync(int id) => await context.Employees
        .FindAsync(id);

}