using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    internal class EmployeeInfo
    {
        public void EmployeeAmountAtWorkRole()
        {
            using var context = new Data.DbProjectContext();
            // Hur många lärare jobbar på de olika avdelningarna? 
            var workRoleCounts = context.Employees
                .GroupBy(e => e.FkworkRole)
                .Select(w => new
                {
                    WorkRole = w.Key,
                    Count = w.Count()
                })
                .ToList();

            // loopar igenom listan och skriver ut datan vi vill ha.
            Console.WriteLine("Amount\tWorkRole\n");
            foreach (var workRoleCount in workRoleCounts)
            {
                Console.WriteLine($"{workRoleCount.Count}\t{workRoleCount.WorkRole}");
            }
        }
    }
}
