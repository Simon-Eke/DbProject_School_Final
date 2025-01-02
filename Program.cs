
namespace DbProject_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------- Visa information om alla elever --------------------------

            // ---------------- Hur många lärare jobbar på de olika avdelningarna? -------

            EmployeeInfo employeeInfo = new();
            employeeInfo.EmployeeAmountAtWorkRole();
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
