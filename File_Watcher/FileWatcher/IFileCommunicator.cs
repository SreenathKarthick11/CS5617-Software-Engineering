
namespace FileWatcher
{
    public interface IFileCommunicator
    {
        void Subscribe(IFileUpdate fileUpdate);
    }
}
