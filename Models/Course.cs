using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseSubject { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Employee Teacher { get; set; } = null!;
}
