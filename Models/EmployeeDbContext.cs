using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreManyToMany.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeesInProject> EmployeesInProjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesInProject>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeesInProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeesInProject)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeesInProject>()
                .HasOne(ep => ep.Project)
                .WithMany(e => e.EmployeesInProject)
                .HasForeignKey(ep => ep.ProjectId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
