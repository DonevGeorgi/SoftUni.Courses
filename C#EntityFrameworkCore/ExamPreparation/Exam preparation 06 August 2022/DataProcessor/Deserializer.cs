namespace Footballers.DataProcessor
{
    using Castle.DynamicProxy.Generators;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var result = new StringBuilder();

            ImportCoachesDto[] coachesDtos = XmlSerializationHelper.Deserialize<ImportCoachesDto[]>(xmlString, "Coaches");

            var coaches = new List<Coach>();

            foreach (var currCoach in coachesDtos)
            {
                if (!IsValid(currCoach) || currCoach.Nationality == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCoach = new Coach()
                {
                    Name = currCoach.Name,
                    Nationality = currCoach.Nationality,
                };

                foreach (var currFootballer in currCoach.Footballers)
                {
                    if (!IsValid(currFootballer))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(currFootballer.ContractStartDate,"dd/MM/yyyy", 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out footballerContractStartDate);

                    if (!isFootballerContractStartDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(currFootballer.ContractEndDate,"dd/MM/yyyy", 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out footballerContractEndDate);

                    if (!isFootballerContractEndDateValid)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (footballerContractStartDate >= footballerContractEndDate)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newFootballer = new Footballer()
                    {
                        Name = currFootballer.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        BestSkillType = (BestSkillType)currFootballer.BestSkillType,
                        PositionType = (PositionType)currFootballer.PositionType
                    };

                    newCoach.Footballers.Add(newFootballer);
                }

                coaches.Add(newCoach);
                result.AppendLine(string.Format(SuccessfullyImportedCoach,newCoach.Name,newCoach.Footballers.Count()));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return result.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var result = new StringBuilder();

            var teamsDto = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            var teams = new List<Team>();

            foreach (var currTeam in teamsDto)
            {
                if (!IsValid(currTeam))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (currTeam.Trophies == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newTeam = new Team() 
                {
                    Name = currTeam.Name,
                    Nationality = currTeam.Nationality,
                    Trophies = currTeam.Trophies,
                };

                foreach (var currId in currTeam.Footballers.Distinct())
                {
                    var currTeamId = context.Footballers.Find(currId);

                    if (currTeamId == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    newTeam.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = currTeamId
                    });
                }

                teams.Add(newTeam);
                result.AppendLine(String.Format(SuccessfullyImportedTeam,newTeam.Name,newTeam.TeamsFootballers.Count()));
            }

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
