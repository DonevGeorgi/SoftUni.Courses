using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string animal = Console.ReadLine();

                if (animal == "Beast!")
                {
                    break;
                }

                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animal == "Cat")
                {
                    Console.WriteLine(animal);
                    Cat currCat = new(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    Console.WriteLine(currCat.ToString());
                }
                else if (animal == "Dog")
                {
                    Console.WriteLine(animal);
                    Dog currDog = new(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    Console.WriteLine(currDog.ToString());
                }
                else if (animal == "Frog")
                {
                    Console.WriteLine(animal);
                    Frog currFrog = new(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    Console.WriteLine(currFrog.ToString());
                }
                else if (animal == "Kitten")
                {
                    Console.WriteLine(animal);
                    Kitten currKitten = new(inputArgs[0], int.Parse(inputArgs[1]));
                    Console.WriteLine(currKitten.ToString());
                }
                else if (animal == "Tomcat")
                {
                    Console.WriteLine(animal);
                    Tomcat currTomcat = new(inputArgs[0], int.Parse(inputArgs[1]));
                    Console.WriteLine(currTomcat.ToString());
                }
            }
        }
    }
}

