using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreManyToMany.Models
{
    /// <summary>
    /// One-Many
    /// </summary>
    /// 
    #region OneToMany
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<EmployeesInProject> EmployeesInProject { get; set; }

    }
    #endregion
    #region ManyToMany
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeesInProject> EmployeesInProject { get; set; }
    }
    public class EmployeesInProject
    {
        public int ProjectId { get; set; }
        public Project Project  { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime AssignedOn { get; set; }

    }
    #endregion

}
