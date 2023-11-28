using Threeuple;

string[] inputOne = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] inputTwo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] inputThree = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string, string> namesAndAdress = new(inputOne[0] + " " + inputOne[1], inputOne[2], string.Join(" ", inputOne[3..]));

CustomTuple<string, int, bool> nameBeer = new(inputTwo[0], int.Parse(inputTwo[1]), inputTwo[2] == "drunk");

CustomTuple<string, double, string> numbers = new(inputThree[0], double.Parse(inputThree[1]), inputThree[2]);

Console.WriteLine(namesAndAdress.ToString());
Console.WriteLine(nameBeer.ToString());
Console.WriteLine(numbers.ToString());