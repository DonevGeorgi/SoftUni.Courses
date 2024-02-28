using System;
using System.Collections.Generic;

namespace P05.ShoppingSpree
{
    internal class ShoppingSpree
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            char[] splitPatern = { ';', '=' };

            string[] inputOfPeoples = Console.ReadLine()
                .Split(splitPatern, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputOfPeoples.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Person person = new Person(inputOfPeoples[0],decimal.Parse(inputOfPeoples[1]));
                    persons.Add(person);
                }
            }

            string[] inputOfProducts = Console.ReadLine()
                .Split(splitPatern,StringSplitOptions.RemoveEmptyEntries);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string nameOfTheClient = commandArgs[0];
                decimal productPrice = decimal.Parse(commandArgs[1]);

                Product product = new Product(nameOfTheClient, productPrice);
                products.Add(product);

                Person.AddToBagProducts(nameOfTheClient,productPrice);

            }
        }
    }

    class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> bagOfProducts { get; set; }

        public void AddToBagProducts(string name,decimal price)
        {
            bagOfProducts.Add(new Product(name, price));
        }
    }

    class Product
    {
        public Product(string nameOfTheProduct, decimal price)
        {
            this.NameOfTheProduct = nameOfTheProduct;
            this.ProductPrice = price;
        }

        public string NameOfTheProduct { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
