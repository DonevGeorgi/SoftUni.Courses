using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            int playerRow = 0;
            int playerCol = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (commandsCount != 0)
            {
                string direction = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                switch (direction)
                {
                    case "up": playerRow--; break;
                    case "down": playerRow++; break;
                    case "left": playerCol--; break;
                    case "right": playerCol++; break;
                }

                if (!IsOutsideTheFiel(playerRow, playerCol, size))
                {
                    PlayerGoingOtherSideFromWhereHeWas(size, ref playerRow, ref playerCol, direction);
                }


                if (matrix[playerRow, playerCol] == 'B')
                {
                    switch (direction)
                    {
                        case "up": playerRow--; break;
                        case "down": playerRow++; break;
                        case "left": playerCol--; break;
                        case "right": playerCol++; break;
                    }

                    if (!IsOutsideTheFiel(playerRow, playerCol, size))
                    {
                        PlayerGoingOtherSideFromWhereHeWas(size, ref playerRow, ref playerCol, direction);
                    }
                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    switch (direction)
                    {
                        case "up": playerRow++; break;
                        case "down": playerRow--; break;
                        case "left": playerCol++; break;
                        case "right": playerCol--; break;
                    }

                    matrix[playerRow, playerCol] = '-';
                }


                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    PrintingMatrix(matrix, size);
                    return;
                }

                matrix[playerRow, playerCol] = 'f';
                commandsCount--;
            }

            Console.WriteLine("Player lost!");
            PrintingMatrix(matrix, size);
        }

        static void PlayerGoingOtherSideFromWhereHeWas(int size, ref int playerRow, ref int playerCol, string direction)
        {
            switch (direction)
            {
                case "up":

                    playerRow = size - 1;

                    break;

                case "down":

                    playerRow = 0;

                    break;

                case "left":

                    playerCol = size - 1;

                    break;

                case "right":

                    playerCol = 0;

                    break;
            }
        }
        static bool IsOutsideTheFiel(int row, int col, int size)
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

