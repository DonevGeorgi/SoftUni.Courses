using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Bombs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                     .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int bombRow = int.Parse(coordinates[i]);
                int bombCols = int.Parse(coordinates[i + 1]);


                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (bombRow == row && bombCols == col && matrix[bombRow, bombCols] > 0)
                        {
                            int bombNummber = matrix[bombRow, bombCols];

                            matrix[row, col] = 0;

                            //left-up-diagonal
                            if (IsValid(row - 1, col - 1, rows, cols))
                            {
                                if (matrix[row - 1, col - 1] > 0)
                                {
                                    int currDetonated = matrix[row - 1, col - 1];
                                    matrix[row - 1, col - 1] = currDetonated - bombNummber;
                                }
                            }

                            //up-middle
                            if (IsValid(row - 1, col, rows, cols))
                            {
                                if (matrix[row - 1, col] > 0)
                                {
                                    int currDetonated = matrix[row - 1, col];
                                    matrix[row - 1, col] = currDetonated - bombNummber;
                                }
                            }

                            //right-up-diagonal
                            if (IsValid(row - 1, col + 1, rows, cols))
                            {
                                if (matrix[row - 1, col + 1] > 0)
                                {
                                    int currDetonated = matrix[row - 1, col + 1];
                                    matrix[row - 1, col + 1] = currDetonated - bombNummber;
                                }
                            }

                            //right-middle
                            if (IsValid(row, col + 1, rows, cols))
                            {
                                if (matrix[row, col + 1] > 0)
                                {
                                    int currDetonated = matrix[row, col + 1];
                                    matrix[row, col + 1] = currDetonated - bombNummber;
                                }
                            }

                            //down-right-diagonal
                            if (IsValid(row + 1, col + 1, rows, cols))
                            {
                                if (matrix[row + 1, col + 1] > 0)
                                {
                                    int currDetonated = matrix[row + 1, col + 1];
                                    matrix[row + 1, col + 1] = currDetonated - bombNummber;
                                }
                            }

                            //down-middle
                            if (IsValid(row + 1, col, rows, cols))
                            {
                                if (matrix[row + 1, col] > 0)
                                {
                                    int currDetonated = matrix[row + 1, col];
                                    matrix[row + 1, col] = currDetonated - bombNummber;
                                }
                            }

                            //down-left-diagonal
                            if (IsValid(row + 1, col - 1, rows, cols))
                            {
                                if (matrix[row + 1, col - 1] > 0)
                                {
                                    int currDetonated = matrix[row + 1, col - 1];
                                    matrix[row + 1, col - 1] = currDetonated - bombNummber;
                                }
                            }

                            //left-middle
                            if (IsValid(row, col - 1, rows, cols))
                            {
                                if (matrix[row, col - 1] > 0)
                                {
                                    int currDetonated = matrix[row, col - 1];
                                    matrix[row, col - 1] = currDetonated - bombNummber;
                                }
                            }
                        }
                    }
                }
            }


            PrintingResult(rows, cols, matrix);
        }

        static bool IsValid(int row, int col, int rows, int cols)
        {
            if (row < rows && row >= 0
                && col < cols && col >= 0)
            {
                return true;
            }

            return false;
        }
        static void PrintingResult(int rows, int cols, int[,] matrix)
        {
            int sum = 0;
            int aliveCells = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
