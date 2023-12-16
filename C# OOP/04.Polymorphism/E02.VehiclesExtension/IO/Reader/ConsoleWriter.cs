using P02.VehiclesExtension.IO.Writer.Interface;

namespace P02.VehiclesExtension.IO.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
