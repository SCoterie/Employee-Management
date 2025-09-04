using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL;

/// <summary>
/// The application's database context using Entity Framework Core.
/// </summary>
/// <param name="options">The options to configure the context.</param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the Employees DbSet, which represents the Employee table in the database.
    /// </summary>
    public DbSet<Employee> Employees { get; set; }


    /// <summary>
    /// Configures the model using Fluent API.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Employee entity configuration
        modelBuilder.Entity<Employee>(entity =>
        {
            // Primary Key
            entity.HasKey(e => e.Id);


            // Properties Configuration
            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.LastName)
                 .IsRequired()
                 .HasMaxLength(50);

            entity.Property(e => e.Department)
                  .IsRequired()
                  .HasMaxLength(80);

            entity.Property(e => e.Address)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.MobileNumber)
                 .IsRequired()
                 .HasMaxLength(10);
        });
    }
}
