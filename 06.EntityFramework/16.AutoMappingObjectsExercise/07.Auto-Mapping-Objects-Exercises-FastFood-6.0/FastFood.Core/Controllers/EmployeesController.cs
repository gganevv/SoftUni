namespace FastFood.Web.Controllers;

using System;
using FastFood.Models;
using FastFood.Services.Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Employees;

public class EmployeesController : Controller
{
    private readonly IEmployeesService employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        this.employeesService = employeesService;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        IEnumerable<RegisterEmployeeViewModel> avaiblePositions =
            await employeesService.GetAllAvaiblePositionsAsync();
        return this.View(avaiblePositions);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }

        await this.employeesService.CreateAsync(model);

        return this.RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<EmployeesAllViewModel> employees =
            await employeesService.GetAllAsync();

        return this.View(employees.ToList());
    }
}