using EmployeeManagement.Models.ViewModels;
using EmployeeManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

public class HomeController(IEmployeeService employeeService) : Controller
{
    private readonly IEmployeeService _employeeService = employeeService;

    public async Task<IActionResult> Index()
    {
        var employess = await _employeeService.GetEmployees();
        return View(employess);
    }

    public IActionResult CreateEmployee() => View();
    public IActionResult Error() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEmployee(EmpViewModel empViewModel)
    {
        if (!ModelState.IsValid)
            return View(empViewModel);

        (bool IsSuccess, string message) = await _employeeService.CreateEmployee(empViewModel);
        ViewBag.Message = message;

        if (IsSuccess)
        {
            ModelState.Clear();
            return View(new EmpViewModel());
        }
        else
            return View(empViewModel);
    }
}
