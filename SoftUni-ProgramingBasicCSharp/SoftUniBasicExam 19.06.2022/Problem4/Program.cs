using System;

namespace Problem4
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int totalRating = 0;

            double totalPrice = 0;

            for (int i = 1; i <= n; i++)
            {
                int serialNum = int.Parse(Console.ReadLine());

                int rating = serialNum % 10;

                serialNum = serialNum / 10;

                if (rating == 2)
                {
                    totalPrice += 0;
                }
                else if (rating == 3)
                {
                    totalPrice += serialNum * 0.50;
                }
                else if (rating == 4)
                {
                    totalPrice += serialNum * 0.70;
                }
                else if (rating == 5)
                {
                    totalPrice += serialNum * 0.85;
                }
                else if (rating == 6)
                {
                    totalPrice += serialNum * 1.00;
                }

                totalRating += rating;
            }

            double averageRating = (double)totalRating / n;

            Console.WriteLine($"{totalPrice:F2}");
            Console.WriteLine($"{averageRating:F2}");
        }
    }
}
