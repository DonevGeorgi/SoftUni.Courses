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

            Console.WriteLine(DeleteProjectById(context));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employeeProjects = context.EmployeesProjects
                                    .Where(p => p.ProjectId == 2)
                                    .ToList();

            foreach (var item in employeeProjects)
            {
                context.EmployeesProjects.Remove(item);
            }

            var project = context.Projects.Find(2);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            foreach (var p in projects)
            {
                result.AppendLine($"{p.Name}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
