namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Intrinsics.X86;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var cellsDto = JsonConvert.DeserializeObject<ImportDepartmentAndCellsDto[]>(jsonString);

            var cells = new List<Department>();

            foreach (var currDepartment in cellsDto)
            {
                if (!IsValid(currDepartment)
                    || cellsDto.Any(c => c.Cells.Count() == 0)
                    || !currDepartment.Cells.All(c => c.CellNumber > 1 && c.CellNumber < 1000))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newDepartment = new Department()
                {
                    Name = currDepartment.Name
                };

                foreach (var currCell in currDepartment.Cells)
                {
                    if (!IsValid(currCell))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newCell = new Cell()
                    {
                        CellNumber = currCell.CellNumber,
                        HasWindow = currCell.HasWindow
                    };

                    newDepartment.Cells.Add(newCell);
                }

                cells.Add(newDepartment);
                result.AppendLine(string.Format(SuccessfullyImportedDepartment,newDepartment.Name,newDepartment.Cells.Count()));
            }

            context.Departments.AddRange(cells);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var prisonerDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var currPrisoner in prisonerDto)
            {
                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(currPrisoner.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(currPrisoner.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (currPrisoner.ReleaseDate == null)
                {
                    isReleaseDateValid = true;
                }

                if (!IsValid(currPrisoner) 
                    || !isIncarcerationDateValid 
                    || !isReleaseDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPrisoner = new Prisoner() 
                {
                    FullName = currPrisoner.FullName,
                    Nickname = currPrisoner.Nickname,
                    Age = currPrisoner.Age,
                    IncarcerationDate = incarcerationDate,  
                    ReleaseDate = releaseDate,
                    Bail = currPrisoner.Bail,
                    CellId = currPrisoner.CellId
                };

                foreach (var currMail in currPrisoner.Mails)
                {
                    if (!IsValid(currMail))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newMail = new Mail()
                    {
                        Description = currMail.Description,
                        Sender = currMail.Sender,
                        Address = currMail.Address
                    };

                    newPrisoner.Mails.Add(newMail);
                }

                prisoners.Add(newPrisoner);
                result.AppendLine(String.Format(SuccessfullyImportedPrisoner,newPrisoner.FullName,newPrisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var result = new StringBuilder();

            var officerDto = XmlSerializationHelper.Deserialize<ImportOfficerPrisonerDto[]>(xmlString, "Officers");

            var officeer = new List<Officer>();

            foreach (var currOfficer in officerDto)
            {
                if (!IsValid(currOfficer) 
                || currOfficer.Position == "Invalid"
                || currOfficer.Position == "Mishka"
                || currOfficer.Weapon == "Bazukaaa")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newOfficer = new Officer()
                {
                    FullName = currOfficer.FullName,
                    Salary = currOfficer.Salary,
                    Position = (Position)Enum.Parse(typeof(Position),currOfficer.Position),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon),currOfficer.Weapon),
                    DepartmentId = currOfficer.DepartmentId
                };

                foreach (var currPrisonerId in currOfficer.Prisoners)
                {
                    var newId = new OfficerPrisoner()
                    {
                        PrisonerId = currPrisonerId.PositionId
                    };

                    newOfficer.OfficerPrisoners.Add(newId);
                }

                officeer.Add(newOfficer);
                result.AppendLine(string.Format(SuccessfullyImportedOfficer,newOfficer.FullName,newOfficer.OfficerPrisoners.Count()));
            }

            context.Officers.AddRange(officeer);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}