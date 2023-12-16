using P04.WildFarm.IO.Writer.Interface;

namespace P04.WildFarm.IO.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
