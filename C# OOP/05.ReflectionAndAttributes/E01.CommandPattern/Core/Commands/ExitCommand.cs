using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        private const int EnvironmentExecuteCode = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(EnvironmentExecuteCode);

            return null;
        }
    }
}
