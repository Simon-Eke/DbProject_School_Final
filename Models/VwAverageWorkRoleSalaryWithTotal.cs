using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class VwAverageWorkRoleSalaryWithTotal
{
    public string WorkRole { get; set; } = null!;

    public decimal? AverageSalary { get; set; }

    public int? NoOfEmployees { get; set; }
}
