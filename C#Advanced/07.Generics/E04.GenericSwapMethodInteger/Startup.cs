using P03.GenericSwapMethodInteders;

Box<int> box = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    box.Add(int.Parse(Console.ReadLine()));
}

int[] indesex = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

box.Swap(indesex[0], indesex[1]);

Console.WriteLine(box.ToString());