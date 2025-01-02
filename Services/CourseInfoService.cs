using DbProject_School.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Services
{
    public class CourseInfoService
    {
        private readonly Data.DbProjectContext _context;

        // Constructor Dependency Injection of DbContext
        public CourseInfoService(Data.DbProjectContext context)
        {
            _context = context;
        }

        public List<CourseInfoModel> GetCourseInfo()
        {
            return _context.Courses
                .GroupJoin(
                    _context.Grades,
                    c => c.CourseId,
                    g => g.FkcourseId,
                    (course, grades) => new CourseInfoModel
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName,
                        CourseSubject = course.CourseSubject,
                        GradeCount = grades.Count()
                    })
                .ToList();
        }
    }
}
