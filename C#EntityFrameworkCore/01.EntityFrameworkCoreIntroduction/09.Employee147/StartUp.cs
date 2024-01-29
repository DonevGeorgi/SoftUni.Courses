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

            Console.WriteLine(GetEmployee147(context));
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .FirstOrDefault(e => e.EmployeeId == 147);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                var projects = context.EmployeesProjects
                    .Select(p => new
                    {
                        p.EmployeeId,
                        p.Project.Name
                    })
                    .Where(p => p.EmployeeId == employee.EmployeeId)
                    .OrderBy(p => p.Name)
                    .ToList();

                foreach (var project in projects)
                {
                    result.AppendLine($"{project.Name}");
                }

            return result.ToString().TrimEnd();
        }
    }
}
