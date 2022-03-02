using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCrudApp.Models.Enums;

namespace MyCrudApp.Models
{
    public class EmployeeDbContext:DbContext
    {
      public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employees");
            modelBuilder.Entity<Employee>()
                .Property(s => s.Department)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(s => s.Gender)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
