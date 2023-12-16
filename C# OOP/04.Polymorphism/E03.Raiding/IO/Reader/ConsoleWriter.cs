using P03.Raiding.IO.Writer.Interface;

namespace P03.VehiclesExtension.IO.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
