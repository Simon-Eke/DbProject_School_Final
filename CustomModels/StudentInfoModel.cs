using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.CustomModels
{
    public class StudentInfoModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string ClassName { get; set; }
        public double? GPA { get; set; } // Nullable, in case GradeScore Per Average is not available yet
        public int? AmountOfGrades { get; set; } // Optional: Helps clarify GPA accuracy


        // SSN contains some personal info that I dont want to display.
        public string DateOfBirth =>
            DateTime.TryParseExact(
                SocialSecurityNumber[..8],
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateOfBirth)
            ? dateOfBirth.ToString("yyyy-MM-dd")
            : "N/A";

        // Display GPA with a fallback message if it's not available
        public string DisplayGPA => GPA.HasValue ? GPA.Value.ToString("0.00") : "N/A"; // Shows "N/A" if GPA is null

        // Display AmountOfGrades with a fallback message if it's not available
        public string DisplayAmountOfGrades => AmountOfGrades.HasValue && AmountOfGrades.Value > 0
            ? AmountOfGrades.Value.ToString()
            : "N/A"; // Shows "N/A" if AmountOfGrades is 0 or not available

    }
}
