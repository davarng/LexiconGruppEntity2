using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeesApp.Infrastructure.Persistance;

public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .Property(e => e.Salary)
            .HasColumnType(SqlDbType.Money.ToString())
            .HasDefaultValue(0m)
            .IsRequired();

        modelBuilder.Entity<Employee>()
            .Property(e => e.Bonus)
            .HasColumnType(SqlDbType.Money.ToString())
            .HasDefaultValue(0m)
            .IsRequired();


        modelBuilder.Entity<Employee>().HasData(
            new Employee()
            {
                Id = 562,
                Name = "Anders Hejlsberg",
                Email = "Anders.Hejlsberg@outlook.com",
            },
            new Employee()
            {
                Id = 62,
                Name = "Kathleen Dollard",
                Email = "k.d@outlook.com",
            },
            new Employee()
            {
                Id = 15662,
                Name = "Mads Torgersen",
                Email = "Admin.Torgersen@outlook.com",
            });
    }
}