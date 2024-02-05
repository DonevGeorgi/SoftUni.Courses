using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //P10.ImportParts
            var inputJson = File.ReadAllText("../../../Datasets/parts.json");
            var output = ImportParts(context, inputJson);

            Console.WriteLine(output);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);
            var suppliers = context.Suppliers.Select(s => s.Id).ToArray();

            var fillteredParts = parts.Where(p => suppliers.Contains(p.SupplierId)).ToArray();
            

            if(fillteredParts.Any()) 
            {
                context.Parts.AddRange(fillteredParts);
                context.SaveChanges();

                return $"Successfully imported {fillteredParts.Count()}.";
            }

            return $"Successfully imported 0.";
        }
    }
}