using Tuple;

string[] inputOne = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] inputTwo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] inputThree = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> namesAndAdress = new(inputOne[0] + " " + inputOne[1], inputOne[2]);

CustomTuple<string, int> nameBeer = new(inputTwo[0], int.Parse(inputTwo[1]));

CustomTuple<int, double> numbers = new(int.Parse(inputThree[0]), double.Parse(inputThree[1]));

Console.WriteLine(namesAndAdress.ToString());
Console.WriteLine(nameBeer.ToString());
Console.WriteLine(numbers.ToString());