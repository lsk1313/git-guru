using DotNetTasks.Abstractions.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DotNetTasks
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> _commands;

        public CommandProcessor(IEnumerable<ICommand> commands)
            => this._commands = commands.ToDictionary(x => x.Number);

        public void Process(int number)
        {
            if (!this._commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this._commands.Values.AsEnumerable();
    }
}
