using DotNetTasks.Tasks.Task4;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTasks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var m = new MultiThreading();

            var watchTask = Task.Factory.StartNew(() => m.WatchFile("file.txt", Console.WriteLine));

            Console.Read();
        }
    }
}
