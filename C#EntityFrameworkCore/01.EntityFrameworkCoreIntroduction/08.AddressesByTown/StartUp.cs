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

            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(t => t.Town)
                .Include(e => e.Employees)
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }

            return result.ToString().TrimEnd();
        }
    }
}
