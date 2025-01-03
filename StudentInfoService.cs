using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    internal class StudentInfoService
    {
        private readonly Data.DbProjectContext _context;

        // Constructor Dependency Injection of DbContext
        public StudentInfoService(Data.DbProjectContext context)
        {
            _context = context;
        }
        
        // I have chosen query syntax for the visual aspect and readability of the code.
        // Method Syntax becomes much more verbose.
        public List<StudentInfoModel> GetStudentInfo()
        {
            var studentInfo = (from student in _context.Students
                               join person in _context.People on student.PersonId equals person.PersonId
                               join classInfo in _context.Classes on student.ClassId equals classInfo.ClassId
                               // Left Joins Grades
                               join grade in _context.Grades on student.StudentId equals grade.FkstudentId into gradeGroup
                               from grade in gradeGroup.DefaultIfEmpty()
                               join gradeMapping in _context.GradesMappings on grade.FkgradeLetter equals gradeMapping.GradeLetter into gradeMappingGroup
                               from gradeMapping in gradeMappingGroup.DefaultIfEmpty()
                               group new { student, person, classInfo, grade, gradeMapping } by new
                               {
                                   student.StudentId,
                                   person.FirstName,
                                   person.LastName,
                                   person.SocialSecurityNumber,
                                   classInfo.ClassName
                               } into grouped
                               select new StudentInfoModel // A custom model made for this.
                               {
                                   StudentId = grouped.Key.StudentId,
                                   FirstName = grouped.Key.FirstName,
                                   LastName = grouped.Key.LastName,
                                   SocialSecurityNumber = grouped.Key.SocialSecurityNumber,
                                   ClassName = grouped.Key.ClassName,
                                   // GPA calculation with fallback handling
                                   GPA = grouped.Average(g => g.gradeMapping != null ? g.gradeMapping.NumericValue : (double?)null),

                                   // Count only non-null grades
                                   AmountOfGrades = grouped.Count(g => g.grade != null) > 0 ? grouped.Count(g => g.grade != null) : (int?)null // If no grades, set AmountOfGrades to null
                               }).ToList();

            return studentInfo;
        }
    }
}
