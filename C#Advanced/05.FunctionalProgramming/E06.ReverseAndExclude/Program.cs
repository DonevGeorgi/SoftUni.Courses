int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

int divisor = int.Parse(Console.ReadLine());

Func<int, int, bool> excluder = (number, divisor) => number % divisor != 0 ? true : false;

Func<int[], Func<int, int, bool>, List<int>> reverseAndExclude = (numbers, excluder) =>
{
    List<int> newArray = new();

    for (int i = numbers.Length - 1; i >= 0; i--)
    {
        if (excluder(numbers[i], divisor))
        {
            newArray.Add(numbers[i]);
        }
    }

    return newArray;
};

List<int> result = new(reverseAndExclude(numbers, excluder));

Console.WriteLine(string.Join(" ", result));