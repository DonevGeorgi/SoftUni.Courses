using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(IncreaseSalaries(context));
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            //context.SaveChanges();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }
    }
}
