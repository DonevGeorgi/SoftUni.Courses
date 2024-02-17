namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var result = new StringBuilder();

            var districtsDto = XmlSerializationHelper.Deserialize<ImportDistrictsDto[]>(xmlDocument, "Districts");

            var districts = new List<District>();

            foreach (var currDistricts in districtsDto)
            {
                if (!IsValid(currDistricts)
                    || districts.Any(d => d.Name == currDistricts.Name))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newDistrict = new District()
                {
                    Name = currDistricts.Name,
                    PostalCode = currDistricts.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region),currDistricts.Region)
                };

                foreach (var currProperties in currDistricts.Properties)
                {
                    DateTime dateOfAcquisition;
                    bool isDateValid = DateTime.TryParseExact(currProperties.DateOfAcquisition, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfAcquisition);

                    if (!IsValid(currProperties)
                        || !isDateValid
                        || districts.Any(d => d.Properties.Any(p => p.PropertyIdentifier == currProperties.PropertyIdentifier))
                        || districts.Any(d => d.Properties.Any(p => p.Address == currProperties.Address)))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newProperty = new Property()
                    {
                        PropertyIdentifier = currProperties.PropertyIdentifier,
                        Area = currProperties.Area,
                        Details = currProperties.Details,
                        Address = currProperties.Address,
                        DateOfAcquisition = dateOfAcquisition,
                    };

                    newDistrict.Properties.Add(newProperty);
                }

                districts.Add(newDistrict);
                result.AppendLine(string.Format(SuccessfullyImportedDistrict,newDistrict.Name,newDistrict.Properties.Count()));
            }

            dbContext.Districts.AddRange(districts);
            dbContext.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var marialStatus = new string[] { "Unmarried", "Married","Divorced","Widowed"};

            var result = new StringBuilder();

            var citizenDto = JsonConvert.DeserializeObject<ImportCitizensDto[]>(jsonDocument);

            var citizens = new List<Citizen>();

            foreach (var currCitizen in citizenDto)
            {
                DateTime birthDate;
                bool isDateValid = DateTime.TryParseExact(currCitizen.BirthDate, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);

                if (!IsValid(currCitizen)
                    || !marialStatus.Contains(currCitizen.MaritalStatus)
                    || !isDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCitizen = new Citizen() 
                {
                    FirstName = currCitizen.FirstName,
                    LastName = currCitizen.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus),currCitizen.MaritalStatus)
                };

                foreach (var currPropertyId in currCitizen.Properties.Distinct())
                {
                    var currProperty = dbContext.Properties.FirstOrDefault(x => x.Id == currPropertyId);

                    if (currProperty == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newPropery = new PropertyCitizen() 
                    {
                        Property = currProperty
                    };

                    newCitizen.PropertiesCitizens.Add(newPropery);
                }


                citizens.Add(newCitizen);
                result.AppendLine(string.Format(SuccessfullyImportedCitizen, newCitizen.FirstName, newCitizen.LastName, newCitizen.PropertiesCitizens.Count()));
            }

            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();

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
