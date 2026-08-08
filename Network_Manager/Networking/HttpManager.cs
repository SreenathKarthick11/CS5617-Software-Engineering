namespace Networking
{
    internal class HttpManager : ICommunicator
    {
        private int count=0;
        public void SendData(string url, string data)
        {
            // Implementation for sending HTTP request
            count++;
            Console.WriteLine($"Sending HTTP request to {url} with data: {data}");
        }

        public int GetCount()
        {
            return count;
        }
    }
}
