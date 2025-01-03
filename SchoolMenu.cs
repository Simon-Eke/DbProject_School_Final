using DbProject_School.Controllers;
using DbProject_School.Data;
using DbProject_School.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School
{
    public class SchoolMenu
    {
        // Method to display the menu and handle user input
        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("--------------- School Management System ---------------");
                Console.WriteLine("1. View All Student Info");
                Console.WriteLine("2. View Teacher Info by Department");
                Console.WriteLine("3. View All Active Courses");
                Console.WriteLine("4. Exit");
                Console.WriteLine("--------------------------------------------------------");
                Console.Write("Please select an option (1-4): ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllStudentInfo();
                        break;
                    case "2":
                        ShowTeacherInfoByDepartment();
                        break;
                    case "3":
                        ShowAllActiveCourses();
                        break;
                    case "4":
                        running = false; // Exit the loop and end the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
                        break;
                }

                // Wait for the user to press Enter to continue after each operation
                if (running)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("\nThank you for using the School Management System!");
        }

        // Helper methods to handle each option
        private void ShowAllStudentInfo()
        {
            Console.Clear();
            Console.WriteLine("1. View All Student Info\n");
            using var studentContext = new DbProjectContext();
            var studentInfoService = new StudentInfoService(studentContext);
            var studentInfoController = new StudentInfoController(studentInfoService);
            studentInfoController.ListAllStudentInfo();
        }

        private void ShowTeacherInfoByDepartment()
        {
            Console.Clear();
            Console.WriteLine("2. View Teacher Info by Department\n");
            using var employeeContext = new DbProjectContext();
            var employeeInfoService = new EmployeeInfoService(employeeContext);
            var employeeInfoController = new EmployeeInfoController(employeeInfoService);
            employeeInfoController.ListAllEmployeeInfo();
        }

        private void ShowAllActiveCourses()
        {
            Console.Clear();
            Console.WriteLine("3. View All Active Courses\n");
            using var courseContext = new DbProjectContext();
            var courseInfoService = new CourseInfoService(courseContext);
            var courseInfoController = new CourseInfoController(courseInfoService);
            courseInfoController.ListAllCourseInfo();
        }
    }
}
