namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var result = new StringBuilder();

            var patientDto = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            var patients = new List<Patient>();

            foreach (var currPatient in patientDto)
            {
                if (!IsValid(currPatient))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPatient = new Patient()
                {
                    FullName = currPatient.FullName,
                    AgeGroup = (AgeGroup)currPatient.AgeGroup,
                    Gender = (Gender)currPatient.Gender,
                };

                foreach (var currId in currPatient.Medicines)
                {
                    if (newPatient.PatientsMedicines.Any(x => x.MedicineId == currId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newId = new PatientMedicine()
                    {
                        MedicineId = currId
                    };

                    newPatient.PatientsMedicines.Add(newId);
                }

                patients.Add(newPatient);
                result.AppendLine(string.Format(SuccessfullyImportedPatient, newPatient.FullName, newPatient.PatientsMedicines.Count()));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return result.ToString().TrimEnd();

        }
        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var result = new StringBuilder();

            var available = new List<Medicine>();

            var pharmacyDto = XmlSerializationHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            var pharmacy = new List<Pharmacy>();

            foreach (var currPharmacy in pharmacyDto)
            {
                if (!IsValid(currPharmacy)
                    || currPharmacy.IsNonStop != "false"
                    && currPharmacy.IsNonStop != "true")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newPharmacy = new Pharmacy()
                {
                    Name = currPharmacy.Name,
                    PhoneNumber = currPharmacy.PhoneNumber,
                    IsNonStop = bool.Parse(currPharmacy.IsNonStop)
                };

                foreach (var currMedicine in currPharmacy.Medicine)
                {
                    DateTime expireDate;
                    bool isExpireValid = DateTime.TryParseExact(currMedicine.ExpiryDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out expireDate);

                    DateTime productionDate;
                    bool isProduceValid = DateTime.TryParseExact(currMedicine.ProductionDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out productionDate);

                    if (!IsValid(currMedicine) 
                        || newPharmacy.Medicines.Any(m => m.Name == currMedicine.Name && m.Producer == currMedicine.Producer)
                        || !isProduceValid && !isExpireValid
                        || productionDate >= expireDate
                        || !Enum.IsDefined(typeof(Category),currMedicine.Category))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newMedicine = new Medicine()
                    {
                        Name = currMedicine.Name,
                        Price = currMedicine.Price,
                        ProductionDate = productionDate,
                        ExpiryDate = expireDate,
                        Producer = currMedicine.Producer,
                        Category = (Category)currMedicine.Category,
                    };

                    newPharmacy.Medicines.Add(newMedicine);
                }

                pharmacy.Add(newPharmacy);
                result.AppendLine(string.Format(SuccessfullyImportedPharmacy, newPharmacy.Name, newPharmacy.Medicines.Count()));
            }

            context.Pharmacies.AddRange(pharmacy);
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
