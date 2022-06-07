using System;
using System.IO;

namespace MarsRover.Services.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _path;
        public FileLogger(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory)) throw new DirectoryNotFoundException($"Couldn't find the directory for {path}");
            
            _path = path;
        }
        
        public void Log(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            using (var writer = new StreamWriter(_path, append:true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
