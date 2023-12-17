using CommandPattern.Core.Contracts;

namespace CommandPattern.CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}
