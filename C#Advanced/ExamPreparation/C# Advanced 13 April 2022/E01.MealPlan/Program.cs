using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(
            Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Stack<int> caloriesIntake = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());

            Dictionary<string, int> foodAndCalories =
                new Dictionary<string, int>();

            foodAndCalories["salad"] = 350;
            foodAndCalories["soup"] = 490;
            foodAndCalories["pasta"] = 680;
            foodAndCalories["steak"] = 790;

            int mealsCount = 0;

            while (true)
            {
                string currMeal = meals.Peek();
                int currCalories = caloriesIntake.Peek();


                switch (currMeal)
                {
                    case "salad":

                        if (currCalories - foodAndCalories["salad"] > 0)
                        {
                            meals.Dequeue();
                            caloriesIntake.Push(caloriesIntake.Pop() - foodAndCalories["salad"]);

                            mealsCount++;
                        }
                        else
                        {
                            meals.Dequeue();

                            int leftCaloriescaloriesIntake = Math.Abs(caloriesIntake.Pop() - foodAndCalories["salad"]);
                            if (caloriesIntake.Any())
                            {
                                caloriesIntake.Push(caloriesIntake.Pop() - leftCaloriescaloriesIntake);
                            }

                            mealsCount++;
                        }

                        break;

                    case "soup":

                        if (currCalories - foodAndCalories["soup"] > 0)
                        {
                            meals.Dequeue();
                            caloriesIntake.Push(caloriesIntake.Pop() - foodAndCalories["soup"]);

                            mealsCount++;
                        }
                        else
                        {
                            meals.Dequeue();

                            int leftCaloriescaloriesIntake = Math.Abs(caloriesIntake.Pop() - foodAndCalories["soup"]);
                            if (caloriesIntake.Any())
                            {
                                caloriesIntake.Push(caloriesIntake.Pop() - leftCaloriescaloriesIntake);
                            }

                            mealsCount++;
                        }

                        break;

                    case "pasta":

                        if (currCalories - foodAndCalories["pasta"] > 0)
                        {
                            meals.Dequeue();
                            caloriesIntake.Push(caloriesIntake.Pop() - foodAndCalories["pasta"]);

                            mealsCount++;
                        }
                        else
                        {
                            meals.Dequeue();

                            int leftCaloriescaloriesIntake = Math.Abs(caloriesIntake.Pop() - foodAndCalories["pasta"]);
                            if (caloriesIntake.Any())
                            {
                                caloriesIntake.Push(caloriesIntake.Pop() - leftCaloriescaloriesIntake);
                            }

                            mealsCount++;
                        }

                        break;

                    case "steak":

                        if (currCalories - foodAndCalories["steak"] > 0)
                        {
                            meals.Dequeue();
                            caloriesIntake.Push(caloriesIntake.Pop() - foodAndCalories["steak"]);

                            mealsCount++;
                        }
                        else
                        {
                            meals.Dequeue();

                            int leftCaloriescaloriesIntake = Math.Abs(caloriesIntake.Pop() - foodAndCalories["steak"]);
                            if (caloriesIntake.Any())
                            {
                                caloriesIntake.Push(caloriesIntake.Pop() - leftCaloriescaloriesIntake);
                            }

                            mealsCount++;

                        }

                        break;
                }



                if (!meals.Any())
                {
                    Console.WriteLine($"John had {mealsCount} meals.");
                    Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesIntake)} calories.");
                    return;
                }

                if (!caloriesIntake.Any())
                {
                    Console.WriteLine($"John ate enough, he had {mealsCount} meals.");
                    Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
                    return;
                }
            }

        }
    }
}
