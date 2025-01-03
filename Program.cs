
namespace DbProject_School
{
    internal class Program
    {

        // TODO - Change the folder and classes within CustomModels to DTO - Data Transfer Object ?
        // TODO - Menu
        // TODO - Hide the connection string lol
        /*
           TODO - Finish up the StudentInfo classes WIP
                - Model DONE
                - Service DONE
                - Controller
                - Formatter WIP
         */
        // TODO - Try to make the formatting into a separate method
        // TODO - Write somethings in the ReadMe file
        // TODO - Add the SQL-queries to the GitHub repo

        static void Main(string[] args)
        {
            // ---------------- Visa information om alla elever --------------------------

            using var studentContext = new Data.DbProjectContext();
            // var studentInfoService = new Services.StudentInfoService(studentContext);
            // var studentInfoController = new Controllers.StudentInfoController(studentInfoService);
            // studentInfoController.ListAllStudentInfo();

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            // ---------------- Hur många lärare jobbar på de olika avdelningarna? -------

            using var employeeContext = new Data.DbProjectContext();
            var employeeInfoService = new Services.EmployeeInfoService(employeeContext);
            var employeeInfoController = new Controllers.EmployeeInfoController(employeeInfoService);
            employeeInfoController.ListAllEmployeeInfo();

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            // ---------------- Visa en lista på alla (aktiva) kurser --------------------

            // Initialize the DbContext, which represents the connection to the database.
            // Using 'using' ensures proper disposal of the context after use.
            using var courseContext = new Data.DbProjectContext();

            // Create an instance of the service layer (CourseInfoService) that will handle business logic.
            // Pass the DbContext to the service so it can interact with the database.
            var courseInfoService = new Services.CourseInfoService(courseContext);

            // Create an instance of the controller (CourseInfoController) responsible for handling the
            // user interface logic. The controller interacts with the service layer to fetch the data.
            var courseInfoController = new Controllers.CourseInfoController(courseInfoService);

            // Call the method that lists all the course information and displays it to the console.
            courseInfoController.ListAllCourseInfo();

            // Wait for the user to press Enter before closing the console window.
            
            Console.ReadLine();
        }
    }
}
