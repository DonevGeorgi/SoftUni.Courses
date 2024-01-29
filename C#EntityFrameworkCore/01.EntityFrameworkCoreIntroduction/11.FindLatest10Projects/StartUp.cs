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

            Console.WriteLine(GetLatestProjects(context));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var project in projects)
            {
                result.AppendLine($"{project.Name}");
                result.AppendLine($"{project.Description}");
                result.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
