using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var town = context.Towns
                .Include(a => a.Addresses)
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Addresses.RemoveRange(town.Addresses);
            context.Towns.Remove(town);

            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.SaveChanges();

            result.AppendLine($"{town.Addresses.Count} addresses in Seattle were deleted");

            return result.ToString().TrimEnd();
        }
    }
}
