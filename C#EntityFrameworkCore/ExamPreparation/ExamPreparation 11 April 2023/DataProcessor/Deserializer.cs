namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var result = new StringBuilder();

            var clientsDto = XmlSerializationHelper.Deserialize<ImportClientsDto[]>(xmlString, "Clients");

            var clients = new List<Client>();

            foreach (var currClient in clientsDto)
            {
                if (!IsValid(currClient))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newClient = new Client()
                {
                    Name = currClient.Name,
                    NumberVat = currClient.NumberVat
                };

                foreach (var currAddresses in currClient.Addresses)
                {
                    if (!IsValid(currAddresses))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newAddresses = new Address()
                    {
                        StreetName = currAddresses.StreetName,
                        StreetNumber = currAddresses.StreetNumber,
                        PostCode = currAddresses.PostCode,
                        City = currAddresses.City,
                        Country = currAddresses.Country
                    };

                    newClient.Addresses.Add(newAddresses);
                }

                clients.Add(newClient);
                result.AppendLine(String.Format(SuccessfullyImportedClients,newClient.Name));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var result = new StringBuilder();

            var invoiceDto = JsonConvert.DeserializeObject<ImportInvoicesDto[]>(jsonString);

            var invoices = new List<Invoice>();

            foreach (var currInvoice in invoiceDto)
            {
                if(!IsValid(currInvoice) || currInvoice.DueDate < currInvoice.IssueDate) 
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newInvoice = new Invoice()
                {
                    Number = currInvoice.Number,
                    IssueDate = currInvoice.IssueDate,
                    DueDate = currInvoice.DueDate,
                    Amount = currInvoice.Amount,
                    CurrencyType = currInvoice.CurrencyType,
                    ClientId = currInvoice.ClientId
                };

                invoices.Add(newInvoice);
                result.AppendLine(string.Format(SuccessfullyImportedInvoices,newInvoice.Number));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var result = new StringBuilder();

            var productsDto = JsonConvert.DeserializeObject<ImportProductsDto[]>(jsonString);

            var products = new List<Product>();

            foreach (var currProduct in productsDto)
            {
                if (!IsValid(currProduct))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newProduct = new Product() 
                {
                    Name = currProduct.Name,
                    Price = currProduct.Price,
                    CategoryType = currProduct.CategoryType
                };

                foreach (var currClientId in currProduct.Clients.Distinct())
                {
                    var currId = context.Clients.FirstOrDefault(c => c.Id == currClientId);

                    if(currId == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newClient = new ProductClient()
                    {
                        ClientId = currClientId
                    };

                    newProduct.ProductsClients.Add(newClient);
                }

                products.Add(newProduct);
                result.AppendLine(string.Format(SuccessfullyImportedProducts,newProduct.Name,newProduct.ProductsClients.Count()));
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
