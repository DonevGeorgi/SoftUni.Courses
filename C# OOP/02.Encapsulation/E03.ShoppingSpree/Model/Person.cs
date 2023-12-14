using System.Text;

namespace P03.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

            products = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage.NameMessage);
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessage.MoneyMessage);
                }

                money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (Money >= product.Money)
            {
                Money -= product.Money;
                Console.WriteLine($"{Name} bought {product.Name}");
                products.Add(product);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            List<string> productsNames = new();

            foreach (Product product in products)
            {
                productsNames.Add(product.Name);
            }

            if (products.Any())
            {
                return $"{Name} - {string.Join(", ", productsNames)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
