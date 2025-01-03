using DbProject_School.Services;
using DbProject_School.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Controllers
{
    public class StudentInfoController
    {
        private readonly StudentInfoService _studentInfoService;

        // Constructor Dependency Injection of StudentInfoService
        public StudentInfoController(StudentInfoService studentInfoService)
        {
            _studentInfoService = studentInfoService;
        }

        public void ListAllStudentInfo()
        {
            var students = _studentInfoService.GetStudentInfo();
            StudentInfoFormatter.PrintStudentInfo(students);
        }
    }
}
