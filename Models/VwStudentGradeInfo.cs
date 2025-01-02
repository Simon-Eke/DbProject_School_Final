using System;
using System.Collections.Generic;

namespace DbProject_School.Models;

public partial class VwStudentGradeInfo
{
    public string Grade { get; set; } = null!;

    public string GradeSetterTeacherName { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string CourseTeacherName { get; set; } = null!;

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public DateOnly GradeDate { get; set; }
}
