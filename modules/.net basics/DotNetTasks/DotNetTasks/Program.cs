using DotNetTasks.Tasks.Task4;
using System;
using System.Threading.Tasks;

namespace DotNetTasks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var m = new MultiThreading();
            m.Changed += File_Changed;
            
            var watchTask = Task.Factory.StartNew(() => m.WatchFile("file.txt"));

            Console.Read();
        }

        private static void File_Changed(object sender, string e)
        {
           Console.WriteLine(e);
        }
    }
}
