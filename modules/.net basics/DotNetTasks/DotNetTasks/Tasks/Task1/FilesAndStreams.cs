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
            var memoryStream = new MemoryStream();

            for (var i = 0; i < 10; i++)
            {
                var line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var buffer = Encoding.UTF8.GetBytes($"{line}\n");
                    
                    memoryStream.Write(buffer, 0, buffer.Length);
                }
            }

            memoryStream.Position = 0;

            var fileStream = new FileStream(this._path, FileMode.Create);

            memoryStream.CopyTo(fileStream);
            fileStream.Flush();

            fileStream.Close();
            memoryStream.Close();
        }

        public string ReadFileOutput()
        {
            using var readonlyFileStream = File.OpenRead(this._path);

            var buffer = new byte[readonlyFileStream.Length];
            var numBytesToRead = (int)readonlyFileStream.Length;
            var numBytesRead = 0;

            while (numBytesToRead > 0)
            {
                var n = readonlyFileStream.Read(buffer, numBytesRead, numBytesToRead);

                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
