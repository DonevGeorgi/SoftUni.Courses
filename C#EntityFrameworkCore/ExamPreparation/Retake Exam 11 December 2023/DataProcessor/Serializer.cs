using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Globalization;
using Trucks.Extensions;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime sortingDate = DateTime.Parse("01/01/2000", CultureInfo.InvariantCulture);

            var result = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= sortingDate)
                .ToArray()
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens
                    .Select(o => new
                    {
                        LastName = o.Citizen.LastName,
                        MaritalStatus = o.Citizen.MaritalStatus.ToString()
                    })
                    .OrderBy(o => o.LastName)
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var result = dbContext.Properties
                .Where(p => p.Area >= 100)
                .ToArray()
                .OrderByDescending(p => p.Area)
                .ThenBy (p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto() 
                { 
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    PostalCode = p.District.PostalCode,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture)
                })
                .ToArray();

            return XmlSerializationHelper.Serialize(result, "Properties");
        }
    }
}
