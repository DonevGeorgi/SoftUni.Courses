using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Probe
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

            int points = 0;

            string moveDirection = string.Empty;

            while ((moveDirection = Console.ReadLine()) != "End")
            {
                int[] moleLocation = MoleLocation(matrix, size);

                int row = moleLocation[0];
                int col = moleLocation[1];

                switch (moveDirection)
                {
                    case "up":

                        if (IsPossitionInRange(row - 1, col, size))
                        {
                            if (matrix[row - 1, col] == 'S')
                            {
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = '-';
                                int[] tunelLocation = LocateOtherTunel(matrix, size);
                                matrix[tunelLocation[0], tunelLocation[1]] = 'M';

                                points -= 3;
                            }
                            else if (matrix[row - 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = 'M';
                            }
                            else
                            {
                                char point = matrix[row - 1, col];
                                points += (int)point - 48;
                                matrix[row, col] = '-';
                                matrix[row - 1, col] = 'M';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        break;

                    case "down":

                        if (IsPossitionInRange(row + 1, col, size))
                        {
                            if (matrix[row + 1, col] == 'S')
                            {
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = '-';
                                int[] tunelLocation = LocateOtherTunel(matrix, size);
                                matrix[tunelLocation[0], tunelLocation[1]] = 'M';

                                points -= 3;
                            }
                            else if (matrix[row + 1, col] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = 'M';
                            }
                            else
                            {
                                char point = matrix[row + 1, col];
                                points += (int)point - 48;
                                matrix[row, col] = '-';
                                matrix[row + 1, col] = 'M';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        break;

                    case "left":

                        if (IsPossitionInRange(row, col - 1, size))
                        {
                            if (matrix[row, col - 1] == 'S')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = '-';
                                int[] tunelLocation = LocateOtherTunel(matrix, size);
                                matrix[tunelLocation[0], tunelLocation[1]] = 'M';

                                points -= 3;
                            }
                            else if (matrix[row, col - 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = 'M';
                            }
                            else
                            {
                                char point = matrix[row, col - 1];
                                points += (int)point - 48;
                                matrix[row, col] = '-';
                                matrix[row, col - 1] = 'M';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        break;

                    case "right":

                        if (IsPossitionInRange(row, col + 1, size))
                        {
                            if (matrix[row, col + 1] == 'S')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = '-';
                                int[] tunelLocation = LocateOtherTunel(matrix, size);
                                matrix[tunelLocation[0], tunelLocation[1]] = 'M';

                                points -= 3;
                            }
                            else if (matrix[row, col + 1] == '-')
                            {
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = 'M';
                            }
                            else
                            {
                                char point = matrix[row, col + 1];
                                points += (int)point - 48;
                                matrix[row, col] = '-';
                                matrix[row, col + 1] = 'M';
                            }
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        break;
                }

                if (points >= 25)
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    Print(matrix, size);
                    return;
                }

            }


            Console.WriteLine("Too bad! The Mole lost this battle!");
            Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            Print(matrix, size);
        }

        static int[] MoleLocation(char[,] matrix, int size)
        {
            int[] location = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        location[0] = row;
                        location[1] = col;
                    }
                }
            }

            return location;
        }
        static bool IsPossitionInRange(int row, int col, int size)
        {
            if (row >= 0 && row < size
                && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
        static int[] LocateOtherTunel(char[,] matrix, int size)
        {
            int[] tunelLocation = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        tunelLocation[0] = row;
                        tunelLocation[1] = col;
                    }
                }
            }

            return tunelLocation;
        }
        static void Print(char[,] matrix, int size)
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
