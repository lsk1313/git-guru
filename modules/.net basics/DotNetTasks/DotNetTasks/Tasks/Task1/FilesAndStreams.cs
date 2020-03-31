using DotNetTasks.Abstractions.Interfaces;
using System;
using System.IO;
using System.Text;

namespace DotNetTasks.Tasks.Task1
{
    public class FilesAndStreams : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Enter data via enter 10 times:");
            this.ReadConsoleInputToMemoryAndWriteToFile();

            Console.WriteLine("Reading data from file to console..");
            var result = this.ReadFileOutput();

            Console.Write($"Result: \n{result}");
        }

        public int Number => 1;

        public string DisplayName => "Task 1: Files and Streams";

        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fileTask1.txt");

        private void ReadConsoleInputToMemoryAndWriteToFile()
        {
            using var memoryStream = new MemoryStream();

            for (var i = 0; i < 10; i++)
            {
                var line = Console.ReadLine();
                var buffer = Encoding.UTF8.GetBytes($"{line}\n");

                memoryStream.Write(buffer, 0, buffer.Length);
            }

            using var fileStream = new FileStream(this._path, FileMode.Create);

            memoryStream.WriteTo(fileStream);
        }

        private string ReadFileOutput()
        {
            using var readonlyFileStream = File.OpenRead(this._path);

            var buffer = new byte[readonlyFileStream.Length];
            readonlyFileStream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
