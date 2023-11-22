using System;
using System.Linq;

namespace P06.JaggedArrayManipulatiorTwo
{
    internal class JaggedArrayManipulatiorTwo
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] dataRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = dataRow;
                int cols = dataRow.Length;

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = dataRow[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs.Length == 4)
                {
                    if (commandArgs[0] == "Add")
                    {
                        if (int.Parse(commandArgs[1]) < rows && int.Parse(commandArgs[1]) >= 0
                            && int.Parse(commandArgs[2]) < matrix[int.Parse(commandArgs[1])].Length && int.Parse(commandArgs[2]) >= 0)
                        {
                            int rowIndex = int.Parse(commandArgs[1]);
                            int colIndex = int.Parse(commandArgs[2]);
                            int number = int.Parse(commandArgs[3]);

                            matrix[rowIndex][colIndex] += number;
                        }
                    }
                    else if (commandArgs[0] == "Subtract")
                    {
                        if (int.Parse(commandArgs[1]) < rows && int.Parse(commandArgs[1]) >= 0
                            && int.Parse(commandArgs[2]) < matrix[int.Parse(commandArgs[1])].Length && int.Parse(commandArgs[2]) >= 0)
                        {
                            int rowIndex = int.Parse(commandArgs[1]);
                            int colIndex = int.Parse(commandArgs[2]);
                            int number = int.Parse(commandArgs[3]);

                            matrix[rowIndex][colIndex] -= number;
                        }
                    }
                }

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
