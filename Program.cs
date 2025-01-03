
namespace DbProject_School
{
    internal class Program
    {

        // TODO - Change the folder and classes within CustomModels to DTO - Data Transfer Object ?
        // TODO - Hide the connection string lol
        // TODO - Write somethings in the ReadMe file
        // TODO - Add the SQL-queries to the GitHub repo

        static void Main(string[] args)
        {
            var menu = new SchoolMenu();
            menu.ShowMenu();
        }
    }
}
