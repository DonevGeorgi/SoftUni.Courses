using P01.Vehicles.IO.Reader.Interface;

namespace P01.Vehicles.IO.Reader
{
    public class ConsoleReader : IReader
    {
        public string ReaderLine() => Console.ReadLine();
    }
}
