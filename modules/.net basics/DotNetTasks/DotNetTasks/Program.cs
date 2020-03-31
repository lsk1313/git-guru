using System;
using System.IO;

namespace DotNetTasks
{
    public class Program
    {
        private static void Main(string[] args)
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

        //private static void CreateFileWatcher()
        //{
        //    if (!File.Exists("file.txt"))
        //    {
        //        File.Create("file.txt");
        //    }

        //    using var fileSystemWatcher = new FileSystemWatcher
        //    {
        //        NotifyFilter = NotifyFilters.LastWrite,
        //        Path = AppDomain.CurrentDomain.BaseDirectory,
        //        Filter = "file.txt",
        //        EnableRaisingEvents = true
        //    };

        //    fileSystemWatcher.Changed += FileSystemWatcher_Changed;
        //}

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.ChangeType);
        }
    }
}
