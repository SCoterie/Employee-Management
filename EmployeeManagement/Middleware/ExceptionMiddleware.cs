using EmployeeManagement.Utility;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace EmployeeManagement.Middleware;

/// <summary>
/// Middleware to handle all unhandled exceptions globally.
/// </summary>
public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch 
        {
            context.Response.Redirect("/Home/Error");
        }
    }
}