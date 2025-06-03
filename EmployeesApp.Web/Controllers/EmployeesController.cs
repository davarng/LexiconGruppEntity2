using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Models;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Web.Controllers;

public class EmployeesController(IEmployeeService service) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var model = await service.GetAllAsync();

        var viewModel = new IndexVM()
        {
            EmployeeVMs = [.. model
            .Select(e => new IndexVM.EmployeeVM()
            {
                Id = e.Id,
                Name = e.Name,
                ShowAsHighlighted = service.CheckIsVIP(e),
            })]
        };

        return View(viewModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    [ServiceFilter(typeof(MyLogServiceFilterAttribute))]
    public async Task<IActionResult> Create(CreateVM viewModel)
    {
        if (!ModelState.IsValid)
            return View();

        Employee employee = new()
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            Salary = viewModel.Salary,
        };

        await service.AddAsync(employee);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("details/{id}")]
    [TypeFilter(typeof(MyLogTypeFilterAttribute))]
    public async Task<IActionResult> Details(int id)
    {
        var model = await service.GetByIdAsync(id);

        DetailsVM viewModel = new()
        {
            Id = model!.Id,
            Name = model.Name,
            Email = model.Email,
            Salary = model.Salary,
        };

        return View(viewModel);
    }
}
