using System;
using DotNetTasks.Tasks.Task1;

namespace DotNetTasks
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var taskFilesAndStreams = new FilesAndStreams();

            Console.WriteLine("Enter data via enter 10 times:");
            var dataInMemory = taskFilesAndStreams.ReadConsoleInputToMemory();

            Console.WriteLine("Writing data from memory to file..");
            taskFilesAndStreams.WriteMemoryStreamToFileStream(dataInMemory);
            
            Console.WriteLine("Reading data from file to console..");
            var result = taskFilesAndStreams.ReadFileOutput();

            Console.Write($"Result: \n{result}");
            Console.Read();
        }
    }
}
