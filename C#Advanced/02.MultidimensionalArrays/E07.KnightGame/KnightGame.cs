using System;
using System.Linq;

namespace P07.KnightGame
{
    internal class KnightGame
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int knightRemoved = 0;

            while (true)
            {
                int bestAttackerRow = 0;
                int bestAttackerCol = 0;
                int bestAttacker = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {

                        if (matrix[row, col] == 'K')
                        {
                            int knightAttacked = 0;

                            //up-left
                            if (IsValid(row - 2, col - 1, rows, cols))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //up-right
                            if (IsValid(row - 2, col + 1, rows, cols))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //right-up
                            if (IsValid(row - 1, col + 2, rows, cols))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //right-down
                            if (IsValid(row + 1, col + 2, rows, cols))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //down-right
                            if (IsValid(row + 2, col + 1, rows, cols))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //down-left
                            if (IsValid(row + 2, col - 1, rows, cols))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //left-down
                            if (IsValid(row + 1, col - 2, rows, cols))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            //left-up
                            if (IsValid(row - 1, col - 2, rows, cols))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    knightAttacked++;
                                }
                            }

                            if (bestAttacker < knightAttacked)
                            {
                                bestAttacker = knightAttacked;
                                bestAttackerRow = row;
                                bestAttackerCol = col;
                            }
                        }

                    }

                }

                if (bestAttacker == 0)
                {
                    break;
                }
                else
                {
                    matrix[bestAttackerRow, bestAttackerCol] = '0';
                    knightRemoved++;
                }

            }

            Console.WriteLine(knightRemoved);
        }

        static bool IsValid(int row, int col, int rows, int cols)
        {
            int indexRow = row;
            int indexCol = col;

            if (indexRow >= 0 && indexRow < rows
                && indexCol >= 0 && indexCol < cols)
            {
                return true;
            }

            return false;
        }
    }
}
