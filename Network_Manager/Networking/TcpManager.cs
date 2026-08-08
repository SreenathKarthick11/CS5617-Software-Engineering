namespace Networking
{
    public class TcpManager : ICommunicator
    {
        private int count=0;

        public virtual void SendData(string address,string data)
        {
            // Implementation for sending data over TCP
            count++;
            Console.WriteLine($"Sending data over TCP to {address}: {data}");
        }

        public int GetCount()
        {
            return count;
        }
    }
}
