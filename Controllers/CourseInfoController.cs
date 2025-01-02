using DbProject_School.Services;
using DbProject_School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Controllers
{
    public class CourseInfoController
    {
        private readonly CourseInfoService _courseInfoService;

        // Constructor Dependency Injection of CourseInfoService
        public CourseInfoController(CourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }

        public void ListAllCourseInfo()
        {
            var courses = _courseInfoService.GetCourseInfo();
            CourseInfoFormatter.PrintCourseInfo(courses);
        }
    }
}
