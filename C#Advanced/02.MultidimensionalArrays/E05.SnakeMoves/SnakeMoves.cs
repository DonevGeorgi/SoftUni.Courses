using System;
using System.Linq;

namespace P05.SnakeMoves
{
    internal class SnakeMoves
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string rowData = Console.ReadLine();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];

            int index = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (rowData.Length == index)
                        {
                            index = 0;
                        }

                        matrix[row, col] = rowData[index];

                        index++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (rowData.Length == index)
                        {
                            index = 0;
                        }

                        matrix[row, col] = rowData[index];

                        index++;
                    }
                }
            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
