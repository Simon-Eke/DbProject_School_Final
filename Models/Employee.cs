using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int FkpersonId { get; set; }

    public string FkworkRole { get; set; } = null!;

    public DateOnly EmployeeStartDate { get; set; }

    public decimal EmployeeSalary { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Person Fkperson { get; set; } = null!;

    public virtual WorkRole FkworkRoleNavigation { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
