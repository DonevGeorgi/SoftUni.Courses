using System;

namespace Task03.Cinema
{
    internal class Cinema
    {
        static void Main(string[] args)
        {
            string typeOfProject = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int colum = int.Parse(Console.ReadLine());

            int rowxColums = row * colum;

            if (typeOfProject == "Premiere")
            {
                Console.WriteLine("{0:F2} leva", rowxColums * 12.00);
            }
            else if (typeOfProject == "Normal")
            {
                Console.WriteLine("{0:F2} leva", rowxColums * 7.50);
            }
            else if (typeOfProject == "Discount")
            {
                Console.WriteLine("{0:F2} leva", rowxColums * 5.00);
            }
        }
    }
}
