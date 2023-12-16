using P03.Raiding.IO.Reader.Interface;

namespace P03.VehiclesExtension.IO.Reader
{
    public class ConsoleReader : IReader
    {
        public string ReaderLine() => Console.ReadLine();
    }
}
