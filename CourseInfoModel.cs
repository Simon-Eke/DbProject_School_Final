using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    public class CourseInfoModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseSubject { get; set; }
        public int GradeCount { get; set; } 

        public string GradeStatus => GradeCount > 0 ? $"{GradeCount} grades" : "Not graded yet"; // $"{course.GradeCount} grades" : "Not graded yet"
    }
}
