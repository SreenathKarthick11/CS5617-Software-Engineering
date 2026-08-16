namespace FileWatcher
{
    public interface IFileUpdate
    {
        void OnFileUpdated(string content);
    }
}
