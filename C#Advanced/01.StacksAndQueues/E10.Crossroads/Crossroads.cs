using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace P10.Crossroads
{
    internal class Crossroads
    {
        static void Main()
        {
            int durationOfGreen = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = string.Empty;
            int carsPasses = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                int currGreen = durationOfGreen;
                int currFreeWindow = durationOfFreeWindow;

                if (input == "green")
                {
                    while (currGreen > 0 && cars.Any())
                    {
                        string currCar = cars.Dequeue();
                        currGreen -= currCar.Length;

                        if (currGreen >= 0)
                        {
                            carsPasses++;
                        }
                        else
                        {
                            int duration = currFreeWindow + currGreen;

                            if (duration < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {currCar[currCar.Length + duration]}.");
                                return;
                            }
                            carsPasses++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPasses} total cars passed the crossroads.");
        }
    }
}
