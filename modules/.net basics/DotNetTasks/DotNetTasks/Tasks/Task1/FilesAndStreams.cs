using System;
using System.IO;
using System.Text;

namespace DotNetTasks.Tasks.Task1
{
    public class FilesAndStreams
    {
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

        public void ReadConsoleInputToMemoryAndWriteToFile()
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
            fileStream.Flush();
        }

        public string ReadFileOutput()
        {
            using var readonlyFileStream = File.OpenRead(this._path);

            var buffer = new byte[readonlyFileStream.Length];
            readonlyFileStream.Read(buffer, 0, buffer.Length);

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
