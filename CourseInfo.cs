using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    internal class CourseInfo
    {
        
        public void ListAllCourseInfo()
        {
            using var context = new Data.DbProjectContext();

            var courseInfo = context.Courses
                .GroupJoin(
                    context.Grades,
                    c => c.CourseId,
                    g => g.FkcourseId,
                    (course, grades) => new
                    {
                        course.CourseId,
                        course.CourseName,
                        course.CourseSubject,
                        GradeCount = grades.Count()
                    })
                .ToList();

            // Determine the maximum lengths of the columns and the headers, with added spacing (+1)
            int maxCourseIdLength = Math.Max(courseInfo.Max(c => c.CourseId.ToString().Length), "CourseId".Length) + 1;
            int maxCourseNameLength = Math.Max(courseInfo.Max(c => c.CourseName.Length), "CourseName".Length) + 1;
            int maxCourseSubjectLength = Math.Max(courseInfo.Max(c => c.CourseSubject.Length), "CourseSubject".Length) + 1;

            // Write Headers
            Console.WriteLine($"{"CourseId".PadRight(maxCourseIdLength)} " +
                              $"{"CourseName".PadRight(maxCourseNameLength)} " +
                              $"{"CourseSubject".PadRight(maxCourseSubjectLength)} " +
                              $"GradeStatus\n");

            // Write the columns
            foreach (var course in courseInfo)
            {
                // Some courses have been graded while some haven't
                string gradeStatus = course.GradeCount > 0 ? $"{course.GradeCount} grades" : "Not graded yet";

                Console.WriteLine($"{course.CourseId.ToString().PadRight(maxCourseIdLength)} " +
                                  $"{course.CourseName.PadRight(maxCourseNameLength)} " +
                                  $"{course.CourseSubject.PadRight(maxCourseSubjectLength)} " +
                                  $"{gradeStatus}");
            }
        }
    }
}
