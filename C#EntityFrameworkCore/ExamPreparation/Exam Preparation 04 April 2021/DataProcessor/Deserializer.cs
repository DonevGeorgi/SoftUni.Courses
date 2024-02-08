// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using Trucks.Extensions;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using System.Security.Cryptography;
    using System.Data.SqlTypes;
    using System.Runtime.ExceptionServices;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var result = new StringBuilder();

            var projectsDto = XmlSerializationHelper.Deserialize<ImportProjectsDto[]>(xmlString, "Projects");

            var projects = new List<Project>();

            foreach (var currProjects in projectsDto)
            {
                DateTime openDate;
                bool isOpenDateValid = DateTime.TryParseExact(currProjects.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                DateTime? nullOpenDate = null;

                if (!String.IsNullOrEmpty(currProjects.DueDate))
                {
                    DateTime dueDate;
                    bool isDueDateValid = DateTime.TryParseExact(currProjects.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate);

                    if (!isDueDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    nullOpenDate = dueDate;
                }


                if (!IsValid(currProjects)
                    || !isOpenDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newProject = new Project()
                {
                    Name = currProjects.Name,
                    OpenDate = openDate,
                    DueDate = nullOpenDate
                };

                foreach (var currTask in currProjects.Tasks)
                {

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(currTask.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(currTask.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!IsValid(currTask)
                        || !isTaskDueDateValid
                        || !isTaskOpenDateValid
                        || taskOpenDate > taskDueDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTask = new Task()
                    {
                        Name = currTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)currTask.ExecutionType,
                        LabelType = (LabelType)currTask.LabelType
                    };

                    newProject.Tasks.Add(newTask);
                }

                projects.Add(newProject);
                result.AppendLine(string.Format(SuccessfullyImportedProject, newProject.Name, newProject.Tasks.Count()));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var result = new StringBuilder();

            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (var currEmployee in employeesDto)
            {
                if (!IsValid(currEmployee))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newEmployee = new Employee()
                {
                    Username = currEmployee.Username,
                    Email = currEmployee.Email,
                    Phone = currEmployee.Phone
                };

                foreach (var currId in currEmployee.Tasks.Distinct())
                {
                    var currTask = context.Tasks.Find(currId);

                    if (currTask == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTask = new EmployeeTask()
                    {
                        TaskId = currTask.Id
                    };

                    newEmployee.EmployeesTasks.Add(newTask);
                }

                employees.Add(newEmployee);
                result.AppendLine(String.Format(SuccessfullyImportedEmployee, newEmployee.Username, newEmployee.EmployeesTasks.Count()));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}