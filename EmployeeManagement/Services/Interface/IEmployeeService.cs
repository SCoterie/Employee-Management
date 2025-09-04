using EmployeeManagement.Models;
using EmployeeManagement.Models.ViewModels;

namespace EmployeeManagement.Services.Interface;

/// <summary>
/// Defines operations related to Employee management.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Creates a new employee record.
    /// </summary>
    /// <param name="empViewModel">The view model containing employee details to be created.</param>
    /// <returns>A status message indicating the result of the operation.</returns>
    Task<(bool IsSuccess, string Message)> CreateEmployee(EmpViewModel empViewModel);

    /// <summary>
    /// Retrieves a list of all employees.
    /// </summary>
    /// <returns>A collection of <see cref="Employee"/> records.</returns>
    Task<IEnumerable<Employee>> GetEmployees();
}

