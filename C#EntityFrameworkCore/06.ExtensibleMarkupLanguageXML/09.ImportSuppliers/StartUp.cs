using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //P01.ImportSuppliers
            var input = File.ReadAllText("../../../Datasets/suppliers.xml");
            var output = ImportSuppliers(context, input);


            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSuppliersDTO[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);

            var importSupplierDTO = xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var suppliers = mapper.Map<Supplier[]>(importSupplierDTO);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }
    }
}