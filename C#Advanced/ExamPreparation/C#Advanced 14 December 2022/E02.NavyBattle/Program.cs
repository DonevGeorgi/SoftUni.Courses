using System.Data.Common;

int size = int.Parse(Console.ReadLine());

int rows = size;
int cols = size;

char[,] matrix = new char[rows, cols];

for (int row = 0; row < rows; row++)
{
    string rowsData = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowsData[col];
    }
}

int hitMines = 0;
int destroyedTargets = 0;

while (true)
{
    string command = Console.ReadLine();

    int[] playerCoordinates = CurrLocation(matrix, size);

    int currPositionRow = playerCoordinates[0];
    int currPositionCol = playerCoordinates[1];

    //Logic
    switch (command)
    {
        case "up":
            if (IsCoordinatesValid(currPositionRow - 1, currPositionCol, size))
            {
                WhereWeGo(matrix, ref hitMines, ref destroyedTargets, currPositionRow - 1, currPositionCol, currPositionRow, currPositionCol);
            }
            break;

        case "down":
            if (IsCoordinatesValid(currPositionRow + 1, currPositionCol, size))
            {
                WhereWeGo(matrix, ref hitMines, ref destroyedTargets, currPositionRow + 1, currPositionCol, currPositionRow, currPositionCol);
            }
            break;

        case "left":
            if (IsCoordinatesValid(currPositionRow, currPositionCol - 1, size))
            {
                WhereWeGo(matrix, ref hitMines, ref destroyedTargets, currPositionRow, currPositionCol - 1, currPositionRow, currPositionCol);
            }
            break;

        case "right":
            if (IsCoordinatesValid(currPositionRow, currPositionCol + 1, size))
            {
                WhereWeGo(matrix, ref hitMines, ref destroyedTargets, currPositionRow, currPositionCol + 1, currPositionRow, currPositionCol);
            }
            break;
    }

    //Lose
    if (hitMines == 3)
    {
        int[] currCoordinates = CurrLocation(matrix, size);
        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currCoordinates[0]}, {currCoordinates[1]}]!");

        MatrixPrint(matrix, rows, cols);

        return;
    }

    //Win
    if (destroyedTargets == 3)
    {
        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");

        MatrixPrint(matrix, rows, cols);

        return;
    }
}

static int[] CurrLocation(char[,] matrix, int size)
{
    int[] playerCoordinates = new int[2];

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            if (matrix[row, col] == 'S')
            {
                playerCoordinates[0] = row;
                playerCoordinates[1] = col;
            }
        }
    }

    return playerCoordinates;
}
static bool IsCoordinatesValid(int row, int col, int size)
{
    if (row >= 0 && row <= size - 1
        && col >= 0 && col <= size - 1)
    {
        return true;
    }

    return false;
}
static void WhereWeGo(char[,] matrix, ref int hitMines, ref int destroyedTargets, int nextRow, int nextCol, int currPositionRow, int currPositionCol)
{
    if (matrix[nextRow, nextCol] == '*')
    {
        matrix[currPositionRow, currPositionCol] = '-';
        matrix[nextRow, nextCol] = 'S';

        hitMines++;
    }

    if (matrix[nextRow, nextCol] == 'C')
    {
        matrix[currPositionRow, currPositionCol] = '-';
        matrix[nextRow, nextCol] = 'S';

        destroyedTargets++;
    }

    if (matrix[nextRow, nextCol] == '-')
    {
        matrix[currPositionRow, currPositionCol] = '-';
        matrix[nextRow, nextCol] = 'S';
    }
}
static void MatrixPrint(char[,] matrix, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(matrix[row, col]);

        }
        Console.WriteLine();
    }
}
