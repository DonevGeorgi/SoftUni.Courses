
using P03.ShoppingSpree.Models;
using System;

List<Person> custumers = new();
List<Product> products = new();

string[] rawInputOfCustomers = Console.ReadLine()
    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < rawInputOfCustomers.Length; i += 2)
{
    string currCustumer = rawInputOfCustomers[i];
    decimal currCustumerMoney = decimal.Parse(rawInputOfCustomers[i + 1]);

    try
    {
        Person currPerson = new(currCustumer, currCustumerMoney);
        custumers.Add(currPerson);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

string[] rawInputOfProducts = Console.ReadLine()
    .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < rawInputOfProducts.Length; i += 2)
{
    string currProduct = rawInputOfProducts[i];
    decimal currProductMoney = decimal.Parse(rawInputOfProducts[i + 1]);

    try
    {
        Product product = new(currProduct, currProductMoney);
        products.Add(product);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

string input = string.Empty;

while ((input = Console.ReadLine()) != "END")
{
    string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string currCustumer = inputArgs[0];
    string currProduct = inputArgs[1];

    foreach (Person custumer in custumers)
    {
        if (custumer.Name == currCustumer)
        {
            custumer.AddProduct(products.Find(p => p.Name == currProduct));
            break;
        }
    }
}

foreach (Person custumer in custumers)
{
    Console.WriteLine(custumer.ToString());
}