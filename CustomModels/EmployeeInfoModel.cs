﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.CustomModels
{
    public class EmployeeInfoModel
    {
        public int EmployeeAmount { get; set; }
        public string EmployeeWorkRole { get; set; }

        // To ensure a plural form of the workRole when printed.
        public string WorkRole => EmployeeAmount <= 1 ? $"{EmployeeWorkRole}" : $"{EmployeeWorkRole}s";
    }
}
