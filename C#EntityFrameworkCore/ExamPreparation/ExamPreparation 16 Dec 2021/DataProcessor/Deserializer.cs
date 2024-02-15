namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.Json.Serialization;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var result = new StringBuilder();

            var countryDto = XmlSerializationHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            var country = new List<Country>();

            foreach (var currCountry in countryDto)
            {
                if (!IsValid(currCountry))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newCountry = new Country() 
                {
                    CountryName = currCountry.CountryName,
                    ArmySize = currCountry.ArmySize
                };

                country.Add(newCountry);
                result.AppendLine(string.Format(SuccessfulImportCountry,newCountry.CountryName,newCountry.ArmySize));
            }

            context.Countries.AddRange(country);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var result = new StringBuilder();

            var manufacturersDtos = XmlSerializationHelper.Deserialize<ImportManufacturersDto[]>(xmlString, "Manufacturers");

            var manufacturers = new List<Manufacturer>();

            foreach (var currManufacturer in manufacturersDtos)
            {
                var uniqueManufacturer = manufacturers.FirstOrDefault(x => x.ManufacturerName == currManufacturer.ManufacturerName);

                if (!IsValid(currManufacturer) || uniqueManufacturer != null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newManufacturer = new Manufacturer()
                {
                    ManufacturerName = currManufacturer.ManufacturerName,
                    Founded = currManufacturer.Founded
                };

                manufacturers.Add(newManufacturer);
                var arg = currManufacturer.Founded.Split(", ").ToArray();
                result.AppendLine(string.Format(SuccessfulImportManufacturer,newManufacturer.ManufacturerName,string.Join(", ", arg[arg.Length - 2],arg.Last())));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var result = new StringBuilder();

            var shellDtos = XmlSerializationHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            var shell = new List<Shell>();

            foreach (var currShell in shellDtos)
            {
                if (!IsValid(currShell))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newShell = new Shell()
                {
                    ShellWeight = currShell.ShellWeight,
                    Caliber = currShell.Caliber
                };

                shell.Add(newShell);
                result.AppendLine(string.Format(SuccessfulImportShell,newShell.Caliber,newShell.ShellWeight));
            }

            context.Shells.AddRange(shell);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            StringBuilder result = new StringBuilder();

            var gunDto = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            var gun = new List<Gun>();

            foreach (var currGun in gunDto)
            {
                if (!IsValid(currGun) || !validGunTypes.Contains(currGun.GunType))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newGun = new Gun()
                {
                    ManufacturerId = currGun.ManufacturerId,
                    GunWeight = currGun.GunWeight,
                    BarrelLength = currGun.BarrelLength,
                    NumberBuild = currGun.NumberBuild,
                    Range = currGun.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), currGun.GunType),
                    ShellId = currGun.ShellId
                };

                foreach (var currCountryId in currGun.Countries.Distinct())
                {
                    newGun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = currCountryId.Id,
                        Gun = newGun
                    });
                }

                gun.Add(newGun);
                result.AppendLine(string.Format(SuccessfulImportGun,newGun.GunType,newGun.GunWeight,newGun.BarrelLength));
            }

            context.Guns.AddRange(gun);
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