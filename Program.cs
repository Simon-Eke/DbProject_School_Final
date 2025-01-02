
namespace DbProject_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            EmployeeInfo employeeInfo = new();
            employeeInfo.EmployeeAmountAtWorkRole();
            Console.ReadLine();

            // Visa en lista på alla (aktiva) kurser 
            CourseInfo courseInfo = new();
            courseInfo.ListAllCourseInfo();
            Console.ReadLine();
        }
    }
}
