using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            int[] mirrorFistPossition = new int[2];
            bool mirrorFist = true;
            int[] mirrorSecondPossition = new int[2];
            int[] armyPossition = new int[2];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'A')
                    {
                        armyPossition[0] = row;
                        armyPossition[1] = col;
                    }
                    else if (matrix[row, col] == 'M' && mirrorFist == true)
                    {
                        mirrorFist = false;
                        mirrorFistPossition[0] = row;
                        mirrorFistPossition[1] = col;
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        mirrorSecondPossition[0] = row;
                        mirrorSecondPossition[1] = col;
                    }
                }
            }

            int armyRow = armyPossition[0];
            int armyCol = armyPossition[1];

            int coins = 0;

            string direction = string.Empty;

            while (true)
            {
                direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":

                        matrix[armyRow, armyCol] = '-';
                        armyRow--;

                        if (!LocationIsValid(armyRow, armyCol, size))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {coins} gold coins.");
                            PrintingMatrix(matrix, size);
                            return;
                        }

                        if (matrix[armyRow, armyCol] == 'M')
                        {
                            if (armyRow == mirrorFistPossition[0] && armyCol == mirrorFistPossition[1])
                            {
                                matrix[mirrorFistPossition[0], mirrorFistPossition[1]] = '-';

                                armyRow = mirrorSecondPossition[0];
                                armyCol = mirrorSecondPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                            else if (armyRow == mirrorSecondPossition[0] && armyCol == mirrorSecondPossition[1])
                            {
                                matrix[mirrorSecondPossition[0], mirrorSecondPossition[1]] = '-';

                                armyRow = mirrorFistPossition[0];
                                armyCol = mirrorFistPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow, armyCol] == '-')
                        {
                            matrix[armyRow, armyCol] = 'A';
                        }
                        else
                        {
                            int currCoin = (int)matrix[armyRow, armyCol] - 48;
                            coins += currCoin;
                            matrix[armyRow, armyCol] = 'A';
                        }

                        break;

                    case "down":

                        matrix[armyRow, armyCol] = '-';
                        armyRow++;

                        if (!LocationIsValid(armyRow, armyCol, size))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {coins} gold coins.");
                            PrintingMatrix(matrix, size);
                            return;
                        }

                        if (matrix[armyRow, armyCol] == 'M')
                        {
                            if (armyRow == mirrorFistPossition[0] && armyCol == mirrorFistPossition[1])
                            {
                                matrix[mirrorFistPossition[0], mirrorFistPossition[1]] = '-';

                                armyRow = mirrorSecondPossition[0];
                                armyCol = mirrorSecondPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                            else if (armyRow == mirrorSecondPossition[0] && armyCol == mirrorSecondPossition[1])
                            {
                                matrix[mirrorSecondPossition[0], mirrorSecondPossition[1]] = '-';

                                armyRow = mirrorFistPossition[0];
                                armyCol = mirrorFistPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow, armyCol] == '-')
                        {
                            matrix[armyRow, armyCol] = 'A';
                        }
                        else
                        {
                            int currCoin = (int)matrix[armyRow, armyCol] - 48;
                            coins += currCoin;
                            matrix[armyRow, armyCol] = 'A';
                        }

                        break;

                    case "left":

                        matrix[armyRow, armyCol] = '-';
                        armyCol--;

                        if (!LocationIsValid(armyRow, armyCol, size))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {coins} gold coins.");
                            PrintingMatrix(matrix, size);
                            return;
                        }
                        if (matrix[armyRow, armyCol] == 'M')
                        {
                            if (armyRow == mirrorFistPossition[0] && armyCol == mirrorFistPossition[1])
                            {
                                matrix[mirrorFistPossition[0], mirrorFistPossition[1]] = '-';

                                armyRow = mirrorSecondPossition[0];
                                armyCol = mirrorSecondPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                            else if (armyRow == mirrorSecondPossition[0] && armyCol == mirrorSecondPossition[1])
                            {
                                matrix[mirrorSecondPossition[0], mirrorSecondPossition[1]] = '-';

                                armyRow = mirrorFistPossition[0];
                                armyCol = mirrorFistPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow, armyCol] == '-')
                        {
                            matrix[armyRow, armyCol] = 'A';
                        }
                        else
                        {
                            int currCoin = (int)matrix[armyRow, armyCol] - 48;
                            coins += currCoin;
                            matrix[armyRow, armyCol] = 'A';
                        }

                        break;

                    case "right":

                        matrix[armyRow, armyCol] = '-';
                        armyCol++;

                        if (!LocationIsValid(armyRow, armyCol, size))
                        {
                            Console.WriteLine("I do not need more swords!");
                            Console.WriteLine($"The king paid {coins} gold coins.");
                            PrintingMatrix(matrix, size);
                            return;
                        }
                        if (matrix[armyRow, armyCol] == 'M')
                        {
                            if (armyRow == mirrorFistPossition[0] && armyCol == mirrorFistPossition[1])
                            {
                                matrix[mirrorFistPossition[0], mirrorFistPossition[1]] = '-';

                                armyRow = mirrorSecondPossition[0];
                                armyCol = mirrorSecondPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                            else if (armyRow == mirrorSecondPossition[0] && armyCol == mirrorSecondPossition[1])
                            {
                                matrix[mirrorSecondPossition[0], mirrorSecondPossition[1]] = '-';

                                armyRow = mirrorFistPossition[0];
                                armyCol = mirrorFistPossition[1];

                                matrix[armyRow, armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow, armyCol] == '-')
                        {
                            matrix[armyRow, armyCol] = 'A';
                        }
                        else
                        {
                            int currCoin = (int)matrix[armyRow, armyCol] - 48;
                            coins += currCoin;
                            matrix[armyRow, armyCol] = 'A';
                        }

                        break;
                }

                if (coins >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {coins} gold coins.");
                    PrintingMatrix(matrix, size);
                    return;
                }
            }


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
        static bool LocationIsValid(int row, int col, int size)
        {
            if (row >= 0 && row < size
                && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }

    }
}



