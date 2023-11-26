string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> honorredKnight = AddSir(names);

Action<string> AddSir(string[] names)
{
    foreach (var name in names)
    {
        Console.WriteLine($"Sir {name}");
    }

    return null;
}