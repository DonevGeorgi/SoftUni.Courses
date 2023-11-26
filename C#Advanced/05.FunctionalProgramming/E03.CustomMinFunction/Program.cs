int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<int[], int> minNum = SerchingMinNum;

Console.WriteLine(minNum(numbers));

static int SerchingMinNum(int[] numbers)
{
    int minNumber = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < minNumber)
        {
            minNumber = number;
        }
    }

    return minNumber;
}