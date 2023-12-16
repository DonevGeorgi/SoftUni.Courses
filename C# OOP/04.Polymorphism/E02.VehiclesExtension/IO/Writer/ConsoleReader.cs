using P02.VehiclesExtension.IO.Reader.Interface;

namespace P02.VehiclesExtension.IO.Reader
{
    public class ConsoleReader : IReader
    {
        public string ReaderLine() => Console.ReadLine();
    }
}
