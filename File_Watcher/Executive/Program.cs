using FileWatcher;

namespace Executive
{   

    class FileUpdateHandler : IFileUpdate
    {
        public void OnFileUpdated(string filePath)
        {
            Console.WriteLine("File content was updated to :");
            Console.WriteLine($"{filePath}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {   
            string path = Path.GetDirectoryName("C:\\Users\\hp\\source\\repos\\Software-Engineering\\File_Watcher\\Executive\\file.txt");

            Console.WriteLine($"Watching directory: {path}");

            FileWatchService fileWatchService = new FileWatchService(path);
            IFileUpdate fileUpdateHandler = new FileUpdateHandler();
            fileWatchService.Subscribe(fileUpdateHandler);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
