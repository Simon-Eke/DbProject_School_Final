using DbProject_School.Services;
using DbProject_School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Controllers
{
    public class EmployeeInfoController
    {
        private readonly EmployeeInfoService _employeeInfoService;

        // Constructor Dependency Injection of EmployeeInfoService
        public EmployeeInfoController(EmployeeInfoService employeeInfoService)
        {
            _employeeInfoService = employeeInfoService;
        }

        public void ListAllEmployeeInfo()
        {
            var employees = _employeeInfoService.GetEmployeeInfo();
            EmployeeInfoFormatter.PrintEmployeeInfo(employees);
        }
    }
}
