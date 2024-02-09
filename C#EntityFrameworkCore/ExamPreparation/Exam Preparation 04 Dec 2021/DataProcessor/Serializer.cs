namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Trucks.Extensions;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context.Theatres
                .Where(t => t.Tickets.Count() > 20 && t.NumberOfHalls >= numbersOfHalls)
                .ToArray()
                .Select(t => new
                {
                    t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets =  t.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .ToArray()
                    .Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(result,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            var result = context.Plays.ToArray();

            return XmlSerializationHelper.Serialize(result, "Plays");
        }
    }
}
