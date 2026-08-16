namespace FileWatcher
{
    public class FileWatchService : IFileCommunicator
    {
            private readonly FileSystemWatcher _fileSystemWatcher;
            private IFileUpdate _fileUpdate;

            public FileWatchService(string path)
            {
                _fileSystemWatcher = new FileSystemWatcher(path);
                _fileSystemWatcher.Filter = "*.txt"; // Watch for text files
                _fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
                _fileSystemWatcher.Changed += OnFileChanged;
                _fileSystemWatcher.EnableRaisingEvents = true;

                Console.WriteLine("File watcher started.");
            }

            public void Subscribe(IFileUpdate fileUpdate)
            {
                _fileUpdate = fileUpdate;
                Console.WriteLine("Subscriber registered.");
            }

            private void OnFileChanged(object sender, FileSystemEventArgs e)
            {
  
                string content = ReadFileWhenReady(e.FullPath);
                _fileUpdate?.OnFileUpdated(content);
        }
            private string ReadFileWhenReady(string filePath)
            {
                while (true){
                   try{
                        using FileStream stream = new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.Read);
                        using StreamReader reader = new StreamReader(stream);
                        return reader.ReadToEnd();
                   }
                   catch (IOException){
                        Thread.Sleep(100);
                   }
                }
            }
    }
}
