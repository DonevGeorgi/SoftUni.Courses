namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;
    using Trucks.Extensions;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime dateToUse = DateTime.Parse(date);

            var result = context.Patients
                .Where(p => p.PatientsMedicines.Any(m => m.Medicine.ProductionDate > dateToUse))
                .Select(p => new ExportPatientDto()
                {
                    Name = p.FullName,
                    Gender = p.Gender.ToString().ToLower(),
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicine = p.PatientsMedicines
                            .Where(m => m.Medicine.ProductionDate > dateToUse)
                            .OrderByDescending(m => m.Medicine.ExpiryDate)
                            .ThenBy(m => m.Medicine.Price)
                            .Select(m => new ExportMedicineDto()
                            {
                                Name = m.Medicine.Name,
                                Price = $"{m.Medicine.Price:F2}",
                                Producer = m.Medicine.Producer,
                                Category = m.Medicine.Category.ToString().ToLower(),
                                ExpireDate = m.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                            })
                            .ToArray()
                })
                .OrderByDescending(p => p.Medicine.Count())
                .ThenBy(p => p.Name)
                .ToArray();

            return XmlSerializationHelper.Serialize(result, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var result = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop == true)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}
