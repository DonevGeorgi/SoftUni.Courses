using P01.Vehicles.IO.Writer.Interface;

namespace P01.Vehicles.IO.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
