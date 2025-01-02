using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class CourseGradeStat
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public double? AvgGrade { get; set; }

    public string? MinGrade { get; set; }

    public string? MaxGrade { get; set; }
}
