using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.CustomModels
{
    public class CourseInfoModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseSubject { get; set; }
        public int GradeCount { get; set; }

        public string GradeStatus => GradeCount == 1 ? "1 grade" : (GradeCount > 0 ? $"{GradeCount} grades" : "N/A");
    }
}
