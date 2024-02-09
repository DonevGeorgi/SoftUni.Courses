namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var validGenres = new string[] { "Drama", "Comedy", "Romance", "Musical" };
            var minimumTime = new TimeSpan(1, 0, 0);

            var result = new StringBuilder();

            var playsDto = XmlSerializationHelper.Deserialize<ImportPlaysDto[]>(xmlString,"Plays");

            var plays = new List<Play>();

            foreach (var currPlay in playsDto)
            {
                var currentTime = TimeSpan.ParseExact(currPlay.Duration, "c", CultureInfo.InvariantCulture);

                if (!IsValid(currPlay)
                    || currentTime < minimumTime
                    || !validGenres.Contains(currPlay.Genre))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPlay = new Play()
                {
                    Title = currPlay.Title,
                    Duration = TimeSpan.Parse(currPlay.Duration),
                    Rating = currPlay.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre),currPlay.Genre),
                    Description = currPlay.Description,
                    Screenwriter = currPlay.Screenwriter
                };

                plays.Add(newPlay);
                result.AppendLine(string.Format(SuccessfulImportPlay,newPlay.Title,newPlay.Genre,newPlay.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var result = new StringBuilder();

            var castsDto = XmlSerializationHelper.Deserialize<ImportCastDto[]>(xmlString, "Casts");

            var casts = new List<Cast>();

            foreach ( var currCast in castsDto ) 
            {
                if (!IsValid(currCast))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCast = new Cast() 
                { 
                    FullName = currCast.FullName,
                    IsMainCharacter = currCast.IsMainCharacter,
                    PhoneNumber = currCast.PhoneNumber,
                    PlayId = currCast.PlayId
                };

                string role = "main";

                if (newCast.IsMainCharacter == false)
                {
                    role = "lesser";
                }

                casts.Add(newCast);
                result.AppendLine(string.Format(SuccessfulImportActor, newCast.FullName, role));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var result = new StringBuilder();

            var theatresDto = JsonConvert.DeserializeObject<ImportTheatresDto[]>(jsonString);

            var theatres = new List<Theatre>();

            foreach (var currTheatres in theatresDto)
            {
                if (!IsValid(currTheatres))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newTheatres = new Theatre() 
                { 
                    Name = currTheatres.Name,
                    NumberOfHalls = currTheatres.NumberOfHalls,
                    Director = currTheatres.Director,
                };

                foreach (var currTicket in currTheatres.Tickets)
                {
                    if (!IsValid(currTicket))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTicket = new Ticket() 
                    {
                        Price = currTicket.Price,
                        RowNumber = currTicket.RowNumber,
                        PlayId = currTicket.PlayId
                    };

                    newTheatres.Tickets.Add(newTicket);
                }

                theatres.Add(newTheatres);
                result.AppendLine(string.Format(SuccessfulImportTheatre,newTheatres.Name,newTheatres.Tickets.Count()));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
