namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Extensions;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var gamesDto = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

            var games = new List<Game>();
            var tags = new List<Tag>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();

            foreach (var currGame in gamesDto)
            {
                DateTime releaseDate;
                bool isDateValid = DateTime.TryParseExact(currGame.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!IsValid(currGame) 
                    || currGame.Tags.Count() == 0
                    || !isDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currDev = developers.FirstOrDefault(x => x.Name == currGame.Developer);

                if(currDev == null)
                {
                    currDev = new Developer()
                    {
                        Name = currGame.Developer
                    };
                    developers.Add(currDev);
                }

                var currGenre = genres.FirstOrDefault(x => x.Name == currGame.Genre);

                if (currGenre == null)
                {
                    currGenre = new Genre()
                    {
                        Name = currGame.Genre
                    };
                    genres.Add(currGenre);
                }

                var newGame = new Game() 
                {
                    Name = currGame.Name,
                    Price = currGame.Price,
                    ReleaseDate = releaseDate,
                    Developer = currDev,
                    Genre = currGenre
                };

                foreach (var currTag in currGame.Tags)
                {
                    if (String.IsNullOrEmpty(currTag))
                    {
                        continue;
                    }

                    var gameTag = tags
                        .FirstOrDefault(t => t.Name == currTag);

                    if (gameTag == null)
                    {
                        var newGameTag = new Tag()
                        {
                            Name = currTag
                        };

                        tags.Add(newGameTag);
                        newGame.GameTags.Add(new GameTag()
                        {
                            Game = newGame,
                            Tag = newGameTag
                        });
                    }
                    else
                    {
                        newGame.GameTags.Add(new GameTag()
                        {
                            Game = newGame,
                            Tag = gameTag
                        });
                    }
                }

                if(newGame.GameTags.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(newGame);
                result.AppendLine(string.Format(SuccessfullyImportedGame, newGame.Name, newGame.Genre.Name, newGame.GameTags.Count()));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var result = new StringBuilder();

            var usersDto = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

            var users = new List<User>();

            foreach (var currUser in usersDto)
            {
                if (!IsValid(currUser))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newUser = new User() 
                {
                    FullName = currUser.FullName,
                    Username = currUser.Username,
                    Email = currUser.Email,
                    Age = currUser.Age
                };

                foreach (var currCard in currUser.Cards)
                {
                    if (!IsValid(currCard))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newCard = new Card()
                    {
                        Number = currCard.Number,
                        Cvc = currCard.Cvc,
                        Type = (CardType)Enum.Parse(typeof(CardType),currCard.Type)
                    };

                    newUser.Cards.Add(newCard);
                }

                users.Add(newUser);
                result.AppendLine(string.Format(SuccessfullyImportedUser, newUser.Username, newUser.Cards.Count()));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var result = new StringBuilder();

            var purchaserDto = XmlSerializationHelper.Deserialize<ImportPurchasesDto[]>(xmlString, "Purchases");

            var purchasers = new List<Purchase>();

            foreach (var currPurchaser in purchaserDto)
            {
                DateTime date;
                bool isValidDate = DateTime.TryParseExact(currPurchaser.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!IsValid(currPurchaser) || !isValidDate)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currDev = context.Cards.FirstOrDefault(x => x.Number == currPurchaser.Card);
                var currGame = context.Games.FirstOrDefault(x => x.Name == currPurchaser.Game);

                var newPurchaser = new Purchase() 
                {
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType),currPurchaser.Type),
                    ProductKey = currPurchaser.ProductKey,
                    Card = currDev,
                    Date = date,
                    Game = currGame
                };

                purchasers.Add(newPurchaser);
                result.AppendLine(string.Format(SuccessfullyImportedPurchase, newPurchaser.Game.Name, newPurchaser.Card.User.Username));
            }

            context.Purchases.AddRange(purchasers);
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