namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.Extensions;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientsDto
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoicesForClientsDto
                        {
                            InvoiceNumber = i.Number,
                            DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                            Currency = i.CurrencyType.ToString(),
                            InvoiceAmount = decimal.Parse(i.Amount.ToString("0.##"))
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(i => i.ClientName)
                .ToArray();
           
            return XmlSerializationHelper.Serialize(clients,"Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var client = context.ProductsClients
                .Where(c => c.Product.ProductsClients.Any(c => c.Client.Name.Length >= nameLength))
                .Select(p => new 
                {
                    Name = p.Product.Name,
                    Price = $"{p.Product.Price:f2}",
                    Category = p.Product.CategoryType.ToString(),
                    Clients = context.Clients
                        .Where(c => c.Name.Length >= nameLength)
                        .Select(c => new
                        {
                            c.Name,
                            c.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.Clients.Count())
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();


            return JsonConvert.SerializeObject(client,Formatting.Indented);
        }
    }
}