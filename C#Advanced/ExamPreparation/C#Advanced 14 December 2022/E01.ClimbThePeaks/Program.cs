Stack<int> dailyPortions = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
Queue<int> stamina = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));

Queue<int> difficulty = new();
Queue<string> peaks = new();

peaks.Enqueue("Vihren");
peaks.Enqueue("Kutelo");
peaks.Enqueue("Banski Suhodol");
peaks.Enqueue("Polezhan");
peaks.Enqueue("Kamenitza");

difficulty.Enqueue(80);
difficulty.Enqueue(90);
difficulty.Enqueue(100);
difficulty.Enqueue(60);
difficulty.Enqueue(70);

int mountain = 0;

while (dailyPortions.Any() && stamina.Any() && difficulty.Any())
{
    int staminaSum = dailyPortions.Peek() + stamina.Peek();

    if (staminaSum >= difficulty.Peek())
    {
        dailyPortions.Pop();
        stamina.Dequeue();

        difficulty.Dequeue();
        mountain++;
    }
    else
    {
        dailyPortions.Pop();
        stamina.Dequeue();
    }
}

if (difficulty.Any())
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}

if (mountain > 0)
{
    Console.WriteLine("Conquered peaks:");

    for (int i = 0; i < mountain; i++)
    {
        Console.WriteLine(peaks.Dequeue());
    }
}