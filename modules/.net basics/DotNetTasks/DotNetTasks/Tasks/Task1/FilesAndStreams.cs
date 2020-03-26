using System;
using System.IO;
using System.Text;

namespace DotNetTasks.Tasks.Task1
{
    public class FilesAndStreams
    {
        private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

        public MemoryStream ReadConsoleInputToMemory()
        {
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);

            for (var i = 0; i < 10; i++)
            {
                var line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    streamWriter.WriteLine(line);
                }
            }

            streamWriter.Flush();
            memoryStream.Position = 0;

            return memoryStream;
        }

        public void WriteMemoryStreamToFileStream(MemoryStream memoryStream)
        {
            var fileStream = new FileStream(this._path, FileMode.Create);

            memoryStream.CopyTo(fileStream);

            fileStream.Flush();
            fileStream.Close();
            memoryStream.Close();
        }

        public string ReadFileOutput()
        {
            using var readonlyFileStream = new FileStream(this._path, FileMode.Open, FileAccess.Read);

            byte[] buffer;

            try
            {
                var length = (int)readonlyFileStream.Length;
                buffer = new byte[length];
                int count;
                var offset = 0;

                while ((count = readonlyFileStream.Read(buffer, offset, length - offset)) > 0)
                    offset += count;
            }
            finally
            {
                readonlyFileStream.Close();
            }

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
