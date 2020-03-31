using System.Collections.Generic;
using DotNetTasks.Abstractions.Interfaces;
using DotNetTasks.Tasks.Task1;
using DotNetTasks.Tasks.Task2;
using DotNetTasks.Tasks.Task3;
using DotNetTasks.Tasks.Task4;

namespace DotNetTasks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var commands = new List<ICommand>(4)
            {
                new FilesAndStreams(),
                new Reflection(),
                new Serialization(),
                new MultiThreading()
            };

            var commandManager = new CommandManager(new CommandProcessor(commands));

            commandManager.Start();
        }
    }
}
