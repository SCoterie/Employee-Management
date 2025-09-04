using EmployeeManagement.DAL;
using EmployeeManagement.Models;
using EmployeeManagement.Models.ViewModels;
using EmployeeManagement.Services.Interface;
using EmployeeManagement.Utility;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services;

/// <summary>
/// Provides services related to employee operations such as creation and retrieval.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EmployeeService"/> class.
/// </remarks>
/// <param name="context">The application's database context.</param>
public class EmployeeService(AppDbContext context) : IEmployeeService
{
    private readonly AppDbContext _context = context;

    /// <summary>
    /// Creates a new employee and saves it to the database.
    /// </summary>
    /// <param name="empViewModel">The view model containing employee data.</param>
    /// <returns>A message indicating success or failure.</returns>
    public async Task<(bool IsSuccess, string Message)> CreateEmployee(EmpViewModel empViewModel)
    {
        if (empViewModel is null)
        {
            return (false, EmpResource.InvalidData);
        }

        var employee = new Employee
        {
            FirstName = empViewModel.FirstName,
            LastName = empViewModel.LastName,
            MobileNumber = empViewModel.MobileNumber,
            Address = empViewModel.Address,
            Department = empViewModel.Department,
            Email = empViewModel.Email
        };

        _context.Employees.Add(employee);
        int result = await _context.SaveChangesAsync();

        return result > 0
        ? (true, EmpResource.EmpCreated)
        : (false, EmpResource.EmpCreationFailed);
    }

    /// <summary>
    /// Retrieves all employees from the database.
    /// </summary>
    /// <returns>A list of <see cref="Employee"/> objects.</returns>
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }
}
