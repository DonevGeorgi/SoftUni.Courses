using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    internal class MatrixShuffling
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArgs.Length == 5)
                {
                    if (commandArgs[0] == "swap")
                    {
                        int firstERow = int.Parse(commandArgs[1]);
                        int firstECol = int.Parse(commandArgs[2]);
                        int secondERow = int.Parse(commandArgs[3]);
                        int secondECol = int.Parse(commandArgs[4]);

                        if (firstERow < rows && firstECol < cols && secondECol < cols && secondERow < rows
                            && firstERow >= 0 && firstECol >= 0 && secondECol >= 0 && secondERow >= 0)
                        {
                            string firstE = matrix[firstERow, firstECol];
                            string secondE = matrix[secondERow, secondECol];

                            matrix[firstERow, firstECol] = secondE;
                            matrix[secondERow, secondECol] = firstE;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                    }

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
