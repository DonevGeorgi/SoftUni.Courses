string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


Action<string> printMessage = PrintNames(names);

Action<string> PrintNames(string[] names)
{
    foreach (var name in names)
    {
        Console.WriteLine(name);
    }

    return null;
}