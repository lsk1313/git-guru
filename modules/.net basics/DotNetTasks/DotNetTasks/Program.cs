using System;
using System.Threading.Tasks;
using DotNetTasks.Tasks.Task4;

namespace DotNetTasks
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main start");
            var multiThreading = new MultiThreading();
            
            Console.WriteLine("FileRead start");
            var fileReadTask = Task.Factory.StartNew(multiThreading.FileTrigger);
            
            Console.WriteLine(fileReadTask.Result);
            Console.WriteLine("FileRead end");

            Console.Read();
        }
    }
}
