List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> commands = new();

string input = string.Empty;
while ((input = Console.ReadLine()) != "Print")
{
    string[] inputArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

    if (inputArgs[0] == "Add filter")
    {
        commands.Add(inputArgs[1] + inputArgs[2], GetPredicate(inputArgs[1], inputArgs[2]));
    }
    else
    {
        commands.Remove(inputArgs[1] + inputArgs[2]);
    }
}

foreach (var command in commands)
{
    people.RemoveAll(command.Value);
}

Console.WriteLine(string.Join(" ", people));

static Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "Starts with":
            return p => p.StartsWith(value);
        case "Ends with":
            return p => p.EndsWith(value);
        case "Contains":
            return p => p.Contains(value);
        case "Length":
            return p => p.Length == int.Parse(value);
        default:
            return default;
    }
}