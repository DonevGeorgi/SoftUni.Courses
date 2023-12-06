using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 8;
            int cols = 8;

            int blackPownRow = 0;
            int blackPownCol = 0;
            int whitePownRow = 0;
            int whitePownCol = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'w')
                    {
                        whitePownRow = row;
                        whitePownCol = col;
                    }

                    if (matrix[row, col] == 'b')
                    {
                        blackPownRow = row;
                        blackPownCol = col;
                    }
                }
            }

            bool whiteTurn = true;

            while (true)
            {

                if (whiteTurn)
                {
                    matrix[whitePownRow, whitePownCol] = '-';

                    if (IsThere(matrix, whitePownRow - 1, whitePownCol + 1, 'w')
                        || IsThere(matrix, whitePownRow - 1, whitePownCol - 1, 'w'))
                    {
                        Console.WriteLine($"Game over! White capture on {CapturedCoordinates(blackPownRow, blackPownCol)}.");

                        matrix[blackPownRow, blackPownCol] = 'w';

                        return;
                    }

                    whitePownRow--;
                    matrix[whitePownRow, whitePownCol] = 'w';
                    whiteTurn = false;

                    if (whitePownRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {CapturedCoordinates(whitePownRow, whitePownCol)}.");
                        return;
                    }
                }
                else
                {
                    matrix[blackPownRow, blackPownCol] = '-';

                    if (IsThere(matrix, blackPownRow + 1, blackPownCol + 1, 'b')
                        || IsThere(matrix, blackPownRow + 1, blackPownCol - 1, 'b'))
                    {
                        Console.WriteLine($"Game over! Black capture on {CapturedCoordinates(whitePownRow, whitePownCol)}.");

                        matrix[whitePownRow, whitePownCol] = 'b';

                        return;
                    }

                    blackPownRow++;
                    matrix[blackPownRow, blackPownCol] = 'b';
                    whiteTurn = true;

                    if (blackPownRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {CapturedCoordinates(blackPownRow, blackPownCol)}.");
                        return;
                    }
                }
            }
        }

        static string CapturedCoordinates(int row, int col)
        {
            string rowCoordinate = string.Empty;
            string colCoordinate = string.Empty;

            switch (row)
            {
                case 0: rowCoordinate = "8"; break;
                case 1: rowCoordinate = "7"; break;
                case 2: rowCoordinate = "6"; break;
                case 3: rowCoordinate = "5"; break;
                case 4: rowCoordinate = "4"; break;
                case 5: rowCoordinate = "3"; break;
                case 6: rowCoordinate = "2"; break;
                case 7: rowCoordinate = "1"; break;
            }

            switch (col)
            {
                case 0: colCoordinate = "a"; break;
                case 1: colCoordinate = "b"; break;
                case 2: colCoordinate = "c"; break;
                case 3: colCoordinate = "d"; break;
                case 4: colCoordinate = "e"; break;
                case 5: colCoordinate = "f"; break;
                case 6: colCoordinate = "g"; break;
                case 7: colCoordinate = "h"; break;
            }

            string coordinates = colCoordinate + rowCoordinate;

            return coordinates;
        }

        static bool IsThere(char[,] matrix, int row, int col, char player)
        {
            if (row >= 0 && row < 8
                && col >= 0 && col < 8)
            {
                if (player == 'w')
                {
                    if (matrix[row, col] == 'b')
                    {
                        return true;
                    }
                }
                else if (player == 'b')
                {
                    if (matrix[row, col] == 'w')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

