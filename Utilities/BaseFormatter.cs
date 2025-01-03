using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject_School.Utilities
{
    // Base class for handling common formatting tasks
    public abstract class BaseFormatter<TModel>
    {
        // Method to calculate the maximum widths of the columns dynamically
        protected static Dictionary<string, int> GetColumnWidths(List<TModel> models, List<string> columnNames)
        {
            var columnWidths = new Dictionary<string, int>();

            foreach (var columnName in columnNames)
            {
                // Using reflection to get property values
                var maxColumnLength = Math.Max(models.Max(m => m.GetType().GetProperty(columnName).GetValue(m)?.ToString().Length ?? 0), columnName.Length);
                columnWidths[columnName] = maxColumnLength + 1; // Add Padding
            }

            return columnWidths;
        }

        // Generic method to format the header with dynamic column widths
        protected static string FormatHeader(Dictionary<string, int> columnWidths, List<string> columnNames)
        {
            var sb = new StringBuilder();
            foreach (var columnName in columnNames)
            {
                sb.Append(columnName.PadRight(columnWidths[columnName]));
            }
            return sb.ToString();
        }

        // Generic method to format model data with dynamic column widths
        protected static string FormatModelData(TModel model, Dictionary<string, int> columnWidths, List<string> columnNames)
        {
            var sb = new StringBuilder();
            foreach (var columnName in columnNames)
            {
                // Using reflection to get property values
                var value = model.GetType().GetProperty(columnName)?.GetValue(model)?.ToString() ?? "N/A";
                sb.Append(value.PadRight(columnWidths[columnName]));
            }
            return sb.ToString();
        }


        // Method to print data (to be implemented by subclasses)
        public abstract void PrintData(List<TModel> models, List<string> columnNames);
    }
}
