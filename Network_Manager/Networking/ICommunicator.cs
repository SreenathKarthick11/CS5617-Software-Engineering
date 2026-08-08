namespace Networking
{
    public interface ICommunicator
    {
        void SendData(string address, string data);
        int GetCount();
    }
}
