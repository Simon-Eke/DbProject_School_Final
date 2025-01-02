using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class VwWorkRoleSalaryWithTotal
{
    public string WorkRole { get; set; } = null!;

    public decimal? TotalSalary { get; set; }

    public int? NoOfEmployees { get; set; }
}
