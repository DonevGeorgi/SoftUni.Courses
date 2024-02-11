namespace VaporStore.DataProcessor
{ 
    using Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using Trucks.Extensions;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(g => g.Purchases.Any())
                    .OrderByDescending(gg => gg.Purchases.Count())
                    .ThenBy(gg => gg.Id)
                    .ToArray()
                    .Select(gg => new 
                    {
                        Id = gg.Id,
                        Title = gg.Name,
                        Developer = gg.Developer.Name,
                        Tags = string.Join(", ",gg.GameTags.Select(t => t.Tag.Name).ToArray()),
                        Players = gg.Purchases.Count()
                    })
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(gg => gg.Purchases.Count())
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();    

            return JsonConvert.SerializeObject(games, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .ToArray()
                .Select(u => new ExportUsersDto
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                    .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(purchaseType))
                    .ToArray()
                    .Select(p => new ExportPurchasesDto
                    {
                        CardNumber = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Games =  new ExportGamesDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpend = context
                        .Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(purchaseType))
                        .Sum(p => p.Game.Price)

                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpend)
                .ThenBy(u => u.Username)
                .ToArray();

            return XmlSerializationHelper.Serialize(users, "Users");
        }
    }
}