using DbProject_School.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Utilities
{
    // Format and print the Employee Info
    public class EmployeeInfoFormatter
    {
        public static void PrintEmployeeInfo(List<EmployeeInfoModel> employees)
        {
            // Determine the maximum lengths of the columns and the headers, with added spacing (+1)
            int maxEmployeeAmountLength = Math.Max(employees.Max(e => e.EmployeeAmount.ToString().Length), "Amount".Length) + 1;

            // Write Headers
            Console.WriteLine($"{"Amount".PadRight(maxEmployeeAmountLength)} " +
                              $"WorkRole\n");

            // Write Columns
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeAmount.ToString().PadRight(maxEmployeeAmountLength)} " +
                                  $"{employee.FormattedWorkRole}");
            }
        }
    }
}
