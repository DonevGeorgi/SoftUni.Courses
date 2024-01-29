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

            Console.WriteLine(GetEmployeesInPeriod(context));
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesProjects = context.Employees
                            .Include(e => e.Manager)
                            .Include(ep => ep.EmployeesProjects)
                            .Take(10)
                            .ToArray();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employeesProjects)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");
            
                if(employee.EmployeesProjects.Count > 0)
                {
                    var employeeProjects = context.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.EmployeeId,
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                        .Where(ep => ep.EmployeeId == employee.EmployeeId)
                        .ToList();

                    foreach (var project in employeeProjects)
                    {
                        if (project.StartDate.Year >= 2001 
                         && project.StartDate.Year <= 2003)
                        {
                            var dateToEnd = project.EndDate != null ? project.EndDate?.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                            result.AppendLine($"--{project.Name} - {project.StartDate.Date.ToString("M/d/yyyy h:mm:ss tt")} - {dateToEnd}");
                            

                        }
                    }
                }
            }
    
            return result.ToString().TrimEnd();
        }
    }
}
