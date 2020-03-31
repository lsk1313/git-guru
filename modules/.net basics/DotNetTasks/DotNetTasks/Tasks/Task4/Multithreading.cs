using DotNetTasks.Abstractions.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTasks.Tasks.Task4
{
    public class MultiThreading : ICommand
    {
        public MultiThreading()
        {
            CreateFile();

            this.Changed += this.File_Changed;
        }

        public void Execute()
        {
            Task.Factory.StartNew(() => this.WatchFile("file.txt"));
        }

        private void File_Changed(object sender, string e)
        {
            Console.WriteLine(e);
        }

        public int Number => 4;

        public string DisplayName => "Task 4: Serialization";

        private string _result = string.Empty;

        public event EventHandler<string> Changed;

        public static void WatchFile()
        {
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

        private void WatchFile(string path)
        {
            while (true)
            {
                var result = ReadFile(path);

                if (this._result != result)
                {
                    this.Changed?.Invoke(this, result);
                    this._result = result;
                }

                Thread.Sleep(5000);
            }
        }

        private static string ReadFile(string path)
        {
            using var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var streamReader = new StreamReader(fileStream);

            return streamReader.ReadToEnd();
        }

        private static void CreateFile()
        {
            var fileStream = new FileStream("file.txt", FileMode.OpenOrCreate);

            fileStream.Close();
        }
    }
}

