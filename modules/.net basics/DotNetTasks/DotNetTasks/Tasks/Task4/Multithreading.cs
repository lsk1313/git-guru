using System;
using System.IO;
using System.Text;
using System.Threading;

namespace DotNetTasks.Tasks.Task4
{
    public class MultiThreading
    {
        public string FileTrigger()
        {
            while (true)
            {
                using var fileStream = File.OpenRead("file.txt");
                Console.WriteLine("Read file...");

                if (fileStream.Length == 0)
                {
                    fileStream.Close();

                    Console.Beep(1000, 100);
                    Thread.Sleep(5000);
                }
                else
                {
                    var buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);

                    return Encoding.UTF8.GetString(buffer);
                }
            }
        }
    }
}

