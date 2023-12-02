using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int holesMade = 1;
            int rodsHit = 0;

            string locationToGo = string.Empty;

            while ((locationToGo = Console.ReadLine()) != "End")
            {
                int[] vankoLocation = LocateVanko(matrix, size);
                int row = vankoLocation[0];
                int col = vankoLocation[1];

                switch (locationToGo)
                {
                    case "up":

                        if (LocationIsValid(row - 1, col, size))
                        {
                            if (matrix[row - 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                            }
                            else if (matrix[row - 1, col] == 'C')
                            {
                                matrix[row, col] = '*';
                                matrix[row - 1, col] = 'E';
                                holesMade++;

                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintingMatrix(matrix, size);
                                return;
                            }
                            else if (matrix[row - 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row - 1}, {col}]!");
                                matrix[row, col] = '*';
                                matrix[row - 1, col] = 'V';
                            }
                            else
                            {
                                matrix[row, col] = '*';
                                matrix[row - 1, col] = 'V';
                                holesMade++;
                            }

                        }

                        break;

                    case "down":

                        if (LocationIsValid(row + 1, col, size))
                        {
                            if (matrix[row + 1, col] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                            }
                            else if (matrix[row + 1, col] == 'C')
                            {
                                matrix[row, col] = '*';
                                matrix[row + 1, col] = 'E';
                                holesMade++;

                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintingMatrix(matrix, size);
                                return;
                            }
                            else if (matrix[row + 1, col] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row + 1}, {col}]!");
                                matrix[row, col] = '*';
                                matrix[row + 1, col] = 'V';
                            }
                            else
                            {
                                matrix[row, col] = '*';
                                matrix[row + 1, col] = 'V';
                                holesMade++;
                            }

                        }

                        break;

                    case "left":

                        if (LocationIsValid(row, col - 1, size))
                        {
                            if (matrix[row, col - 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                            }
                            else if (matrix[row, col - 1] == 'C')
                            {
                                matrix[row, col] = '*';
                                matrix[row, col - 1] = 'E';
                                holesMade++;

                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintingMatrix(matrix, size);
                                return;
                            }
                            else if (matrix[row, col - 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row}, {col - 1}]!");
                                matrix[row, col] = '*';
                                matrix[row, col - 1] = 'V';
                            }
                            else
                            {
                                matrix[row, col] = '*';
                                matrix[row, col - 1] = 'V';
                                holesMade++;
                            }

                        }

                        break;

                    case "right":

                        if (LocationIsValid(row, col + 1, size))
                        {
                            if (matrix[row, col + 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodsHit++;
                            }
                            else if (matrix[row, col + 1] == 'C')
                            {
                                matrix[row, col] = '*';
                                matrix[row, col + 1] = 'E';
                                holesMade++;

                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintingMatrix(matrix, size);
                                return;
                            }
                            else if (matrix[row, col + 1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{row}, {col + 1}]!");
                                matrix[row, col] = '*';
                                matrix[row, col + 1] = 'V';
                            }
                            else
                            {
                                matrix[row, col] = '*';
                                matrix[row, col + 1] = 'V';
                                holesMade++;
                            }

                        }

                        break;
                }

            }

            Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");
            PrintingMatrix(matrix, size);
        }


        static int[] LocateVanko(char[,] matrix, int size)
        {
            int[] location = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        location[0] = row;
                        location[1] = col;
                    }
                }
            }

            return location;
        }
        static bool LocationIsValid(int row, int col, int size)
        {
            if (row >= 0 && row < size
                && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
        static void PrintingMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
