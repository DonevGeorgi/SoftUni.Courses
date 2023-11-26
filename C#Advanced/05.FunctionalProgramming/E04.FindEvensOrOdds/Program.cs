using System.Net;
using System.Text;

int[] range = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

Func<int, int, List<int>> generateList = (start, end) =>
{
    List<int> newArray = new List<int>();

    for (int i = range[0]; i <= range[1]; i++)
    {
        newArray.Add(i);
    }

    return newArray;
}
;

Predicate<int> oddOrEven;

bool isEven = Console.ReadLine() == "even";

List<int> newArray = new(generateList(range[0], range[1]));


if (isEven)
{
    oddOrEven = number => number % 2 == 0;
}
else
{
    oddOrEven = number => number % 2 != 0;
}

List<int> result = new();

foreach (var number in newArray)
{
    if (oddOrEven(number))
    {
        result.Add(number);
    }
}

Console.WriteLine(string.Join(" ", result));