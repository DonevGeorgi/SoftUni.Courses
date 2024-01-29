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

            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    d.Name,
                    d.Manager,
                    d.Employees
                })
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .ToArray();

            foreach (var department in departments)
            {
                result.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
