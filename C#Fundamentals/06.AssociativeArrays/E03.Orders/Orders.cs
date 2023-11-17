using System;
using System.Collections.Generic;

namespace P03.Orders
{
    internal class Orders
    {
        static void Main()
        {
            Dictionary<string, List<decimal>> orders =
                new Dictionary<string, List<decimal>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string nameOfTheProduct = inputArgs[0];
                decimal priceOfSindgeProduct = decimal.Parse(inputArgs[1]);
                int quantityOfProducts = int.Parse(inputArgs[2]);

                if (!orders.ContainsKey(nameOfTheProduct))
                {
                    orders.Add(nameOfTheProduct, new List<decimal>() { priceOfSindgeProduct, quantityOfProducts });
                }
                else
                {
                    orders[nameOfTheProduct][0] = priceOfSindgeProduct;
                    orders[nameOfTheProduct][1] += quantityOfProducts;
                }

            }

            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Key} -> {order.Value[0] * order.Value[1]:f2}");
            }
        }
    }
}
