using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person peter = new(2);

            Console.WriteLine(peter.Name);
            Console.WriteLine(peter.Age);
        }
    }
}