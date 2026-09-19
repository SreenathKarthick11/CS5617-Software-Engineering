using System;
using System.IO;

namespace Service
{
    public class FileService
    {
        private readonly string filePath;

        public FileService()
        {
            filePath = Path.Combine(
                Directory.GetParent(
                    AppDomain.CurrentDomain.BaseDirectory
                )!.Parent!.Parent!.Parent!.FullName,
                "data.txt"
            );
        }

        public bool FileExists()
        {
            return File.Exists(filePath);
        }

        public string ReadFile()
        {
            return File.ReadAllText(filePath);
        }

        public DateTime GetLastModified()
        {
            return File.GetLastWriteTime(filePath);
        }
    }
}