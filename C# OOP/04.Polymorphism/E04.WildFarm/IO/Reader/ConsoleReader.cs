using P04.WildFarm.IO.Reader.Interface;

namespace P04.WildFarm.IO.Reader
{
    public class ConsoleReader : IReader
    {
        public string ReaderLine() => Console.ReadLine();
    }
}
