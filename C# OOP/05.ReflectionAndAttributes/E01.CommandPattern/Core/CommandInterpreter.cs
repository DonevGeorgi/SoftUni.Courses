using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] commandArguments = inputArgs.Skip(1).ToArray();

            string className = inputArgs[0] + "Command";

            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == className);

            if (type == null)
            {
                throw new InvalidOperationException("Command not found");
            }

            ICommand commandInstance = Activator.CreateInstance(type) as ICommand;

            string message = commandInstance.Execute(commandArguments);

            return message.ToString();
        }
    }
}
