using System.Collections.Generic;

namespace DotNetTasks.Abstractions.Interfaces
{
    public interface ICommandProcessor
    {
        void Process(int command);

        IEnumerable<ICommand> Commands { get; }
    }
}
