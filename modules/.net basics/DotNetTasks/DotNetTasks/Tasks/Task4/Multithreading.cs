using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTasks.Tasks.Task4
{
    public class MultiThreading
    {
        private string _result = string.Empty;
        
        public static void WatchFile()
        {
            if (!File.Exists("file.txt"))
            {
                File.Create("file.txt");
            }

            using var fileSystemWatcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastWrite,
                Path = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "file.txt",
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Changed += FileSystemWatcher_Changed;

            Console.Read();
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            using var streamReader = new StreamReader(File.Open("file.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            Console.WriteLine(streamReader.ReadToEnd());
        }

        public void WatchFile(string path, Action<string> action)
        {
            while (true)
            {
                var watchTask = Task.Factory.StartNew(() => ReadFile(path));

                var result = watchTask.Result;

                if (this._result != result)
                {
                    action(watchTask.Result);
                    this._result = result;
                    Thread.Sleep(5000);
                }
                else
                {
                    Thread.Sleep(5000);
                }
            }
        }

        private static string ReadFile(string path)
        {
            using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var streamReader = new StreamReader(fileStream);

            return streamReader.ReadToEnd();
        }
    }
}

