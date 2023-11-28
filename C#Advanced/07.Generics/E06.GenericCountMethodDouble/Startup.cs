using P03.GenericCountMethodDoubles;

Box<double> box = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    box.Add(double.Parse(Console.ReadLine()));
}

double stringForComparison = double.Parse(Console.ReadLine());

Console.WriteLine(box.Count(stringForComparison));