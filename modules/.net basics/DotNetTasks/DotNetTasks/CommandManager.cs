using DotNetTasks.Abstractions.Interfaces;
using System;
using System.Text;

namespace DotNetTasks
{
    public class CommandManager
    {
        private readonly ICommandProcessor _processor;
        private string _info;

        public CommandManager(ICommandProcessor processor) => this._processor = processor;

        public void Start()
        {
            this.SetupInfo();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(this._info);

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)
                    ||
                    !int.TryParse(input, out var command))
                    continue;

                if (command == 0) return;

                this._processor.Process(command);

                Console.WriteLine("RETURN to continue...");
                Console.ReadLine();
            }
        }

        private void SetupInfo()
        {
            var sb = new StringBuilder();
            var commands = this._processor.Commands;

            sb.AppendLine("Select task:");

            foreach (var command in commands) sb.AppendLine($"{command.Number}. {command.DisplayName}");

            this._info = sb.Append("0. Exit").ToString();
        }
    }
}
