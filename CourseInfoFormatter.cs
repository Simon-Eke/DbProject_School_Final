using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    public class CourseInfoFormatter
    {
        // Format and print the Course Info
        public static void PrintCourseInfo(List<CourseInfoModel> courses)
        {
            // Determine the maximum lengths of the columns and the headers, with added spacing (+1)
            int maxCourseIdLength = Math.Max(courses.Max(c => c.CourseId.ToString().Length), "CourseId".Length) + 1;
            int maxCourseNameLength = Math.Max(courses.Max(c => c.CourseName.Length), "CourseName".Length) + 1;
            int maxCourseSubjectLength = Math.Max(courses.Max(c => c.CourseSubject.Length), "CourseSubject".Length) + 1;

            // Write Headers
            Console.WriteLine($"{"CourseId".PadRight(maxCourseIdLength)} " +
                              $"{"CourseName".PadRight(maxCourseNameLength)} " +
                              $"{"CourseSubject".PadRight(maxCourseSubjectLength)} " +
                              $"GradeStatus\n");

            // Write the columns
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CourseId.ToString().PadRight(maxCourseIdLength)} " +
                                  $"{course.CourseName.PadRight(maxCourseNameLength)} " +
                                  $"{course.CourseSubject.PadRight(maxCourseSubjectLength)} " +
                                  $"{course.GradeStatus}");
            }
        }
    }
}
