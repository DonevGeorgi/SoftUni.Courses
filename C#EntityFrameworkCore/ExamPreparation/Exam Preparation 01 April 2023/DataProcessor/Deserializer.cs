namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var result = new StringBuilder();

            var creatorsDto = XmlSerializationHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            var creators = new List<Creator>();

            foreach (var currCreator in creatorsDto)
            {
                if (!IsValid(currCreator))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCreator = new Creator() 
                {
                    FirstName = currCreator.FirstName,
                    LastName = currCreator.LastName
                };

                foreach (var currBoardgame in currCreator.Boardgames)
                {
                    if (!IsValid(currBoardgame))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newBoardgame = new Boardgame()
                    { 
                        Name = currBoardgame.Name,
                        Rating = currBoardgame.Rating,
                        YearPublished = currBoardgame.YearPublished,
                        CategoryType = (CategoryType)Enum.Parse(typeof(CategoryType),currBoardgame.CategoryType),
                        Mechanics = currBoardgame.Mechanics
                    };

                    newCreator.Boardgames.Add(newBoardgame);
                }

                creators.Add(newCreator);
                result.AppendLine(string.Format(SuccessfullyImportedCreator, newCreator.FirstName, newCreator.LastName, newCreator.Boardgames.Count()));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var result = new StringBuilder();

            var sellersDto = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            var sellers = new List<Seller>();

            foreach (var currSeller in sellersDto)
            {
                if (!IsValid(currSeller))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newSeller = new Seller() 
                {
                    Name = currSeller.Name,
                    Address = currSeller.Address,
                    Country = currSeller.Country,
                    Website = currSeller.Website
                };

                foreach (var currId in currSeller.Boardgames.Distinct())
                {
                    var boardgameId = context.Boardgames.FirstOrDefault(x => x.Id == currId);

                    if (boardgameId == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newBoardgame = new BoardgameSeller() 
                    { 
                        BoardgameId = currId 
                    };

                    newSeller.BoardgamesSellers.Add(newBoardgame);
                }

                sellers.Add(newSeller);
                result.AppendLine(string.Format(SuccessfullyImportedSeller,newSeller.Name,newSeller.BoardgamesSellers.Count()));
            }

            context.Sellers.AddRange(sellers);
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
