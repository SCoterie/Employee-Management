using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.ViewModels;

public class EmpViewModel
{
    [Required(ErrorMessage = "Enter the first name")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Enter the last name")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Enter the department")]
    [MaxLength(80, ErrorMessage = "Department name cannot exceed 80 characters")]
    public string? Department { get; set; }

    [Required(ErrorMessage = "Enter the address")]
    [MaxLength(150, ErrorMessage = "Address cannot exceed 150 characters")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Enter the mobile number")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits")]
    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "Enter the email")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string? Email { get; set; }
}
