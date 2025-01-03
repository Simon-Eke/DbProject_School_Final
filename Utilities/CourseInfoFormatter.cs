using DbProject_School.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Utilities
{
    public class CourseInfoFormatter : BaseFormatter<CourseInfoModel>
    {
        public override void PrintData(List<CourseInfoModel> courses, List<string> columnNames)
        {
            // Calculate the column Widths (Aka the padding needed to align the result)
            var columnWidths = GetColumnWidths(courses, columnNames);

            // Write Headers
            Console.WriteLine(FormatHeader(columnWidths, columnNames));

            // Adjust the separator line length to match the sum of column widths (The "pipe symbol" of the last column is removed)
            Console.WriteLine("\n" + new string('-', columnWidths.Values.Sum() + (columnNames.Count - 1) * 3) + "\n");

            // Write the columns for each course
            foreach (var course in courses)
            {
                Console.WriteLine(FormatModelData(course, columnWidths, columnNames));
            }
        }
    }
}
