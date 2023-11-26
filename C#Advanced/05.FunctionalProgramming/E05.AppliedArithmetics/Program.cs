int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<int[], string, int[]> operations = (numbers, command) =>
{
    switch (command)
    {
        case "add":
            return numbers = numbers.Select(n => n + 1).ToArray();
        case "multiply":
            return numbers = numbers.Select(n => n * 2).ToArray();
        case "subtract":
            return numbers = numbers.Select(n => n - 1).ToArray();
        default:
            return default;
    }
};

Action<int[]> printing = numbers => Console.WriteLine(string.Join(" ", numbers));

string input = string.Empty;

while ((input = Console.ReadLine()) != "end")
{
    if (input == "print")
    {
        printing(numbers);
    }
    else
    {
        numbers = operations(numbers, input);
    }
}

