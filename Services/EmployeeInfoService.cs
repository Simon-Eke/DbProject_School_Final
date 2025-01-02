using DbProject_School.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Services
{
    public class EmployeeInfoService
    {
        private readonly Data.DbProjectContext _context;

        // Constructor Dependency Injection of DbContext
        public EmployeeInfoService(Data.DbProjectContext context)
        {
            _context = context;
        }

        public List<EmployeeInfoModel> GetEmployeeInfo()
        {
            return _context.WorkRoles
                .GroupJoin(
                    _context.Employees,
                    wr => wr.WorkRole1,
                    e => e.FkworkRole,
                    (wr, employees) => new EmployeeInfoModel
                    {
                        EmployeeAmount = employees.Count(),
                        EmployeeWorkRole = wr.WorkRole1
                    })
                .ToList();
        }
    }
}
