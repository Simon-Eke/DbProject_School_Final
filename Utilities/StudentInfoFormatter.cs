using DbProject_School.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Utilities
{
    public class StudentInfoFormatter
    {
        public static void PrintStudentInfo(List<StudentInfoModel> students)
        {
            // Calculate the maximum lengths of the columns dynamically
            var columnWidths = GetColumnWidths(students);

            // Write Headers
            Console.WriteLine(FormatHeader(columnWidths));

            // Write empty row
            Console.WriteLine("");

            // Write the columns for each student
            foreach (var student in students)
            {
                Console.WriteLine(FormatStudentInfo(student, columnWidths));
            }
        }

        // Helper method to calculate the maximum widths of each column
        public static Dictionary<string, int> GetColumnWidths(List<StudentInfoModel> students)
        {
            return new Dictionary<string, int>
            {
                { "StudentId", Math.Max(students.Max(s => s.StudentId.ToString().Length), "StudentId".Length) + 1 },
                { "FirstName", Math.Max(students.Max(s => s.FirstName.Length), "FirstName".Length) + 1 },
                { "LastName", Math.Max(students.Max(s => s.LastName.Length), "LastName".Length) + 1 },
                { "ClassName", Math.Max(students.Max(s => s.ClassName.Length), "ClassName".Length) + 1 },
                { "GPA", Math.Max(students.Max(s => s.DisplayGPA.Length), "GPA".Length) + 1 },
                { "AmountOfGrades", Math.Max(students.Max(s => s.DisplayAmountOfGrades.Length), "AmountOfGrades".Length) + 1 }
            };
        }

        // Format the header with dynamic column widths
        public static string FormatHeader(Dictionary<string, int> columnWidths)
        {
            var sb = new StringBuilder();
            sb.Append("StudentId".PadRight(columnWidths["StudentId"]));
            sb.Append("FirstName".PadRight(columnWidths["FirstName"]));
            sb.Append("LastName".PadRight(columnWidths["LastName"]));
            sb.Append("ClassName".PadRight(columnWidths["ClassName"]));
            sb.Append("GPA".PadRight(columnWidths["GPA"]));
            sb.Append("AmountOfGrades".PadRight(columnWidths["AmountOfGrades"]));

            return sb.ToString();
        }

        // Format a student's data with dynamic column widths
        public static string FormatStudentInfo(StudentInfoModel student, Dictionary<string, int> columnWidths)
        {
            var sb = new StringBuilder();
            sb.Append(student.StudentId.ToString().PadRight(columnWidths["StudentId"]));
            sb.Append(student.FirstName.PadRight(columnWidths["FirstName"]));
            sb.Append(student.LastName.PadRight(columnWidths["LastName"]));
            sb.Append(student.ClassName.PadRight(columnWidths["ClassName"]));
            sb.Append(student.DisplayGPA.PadRight(columnWidths["GPA"]));
            sb.Append(student.DisplayAmountOfGrades.PadRight(columnWidths["AmountOfGrades"]));

            return sb.ToString();
        }
    }
}
