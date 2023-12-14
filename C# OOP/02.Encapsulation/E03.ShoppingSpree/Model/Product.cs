namespace P03.ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal money;

        public Product(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
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
    }
}