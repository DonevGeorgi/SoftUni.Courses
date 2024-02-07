namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Trucks.Extensions;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var result = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new ExportCreatorDto()
                {
                    Name = $"{c.FirstName} {c.LastName}",
                    BoardgameCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames
                    .ToArray()
                    .Select(g => new ExportBoardgameDto()
                    {
                        Name = g.Name,
                        Year = g.YearPublished
                    })
                    .OrderBy(c => c.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.BoardgameCount)
                .ThenBy(c => c.Name)
                .ToArray();


            return XmlSerializationHelper.Serialize(result, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var result = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(s => s.Boardgame.YearPublished >= year && s.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                    .ToArray()
                    .OrderByDescending(b => b.Boardgame.Rating)
                    .ThenBy(b => b.Boardgame.Name)    
                    .Select(b => new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}