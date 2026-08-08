using Networking;

namespace Executive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FactoryNetworkManager factory = new FactoryNetworkManager();

            ICommunicator communicator = factory.Create("LAN");

            communicator.SendData("192.168.1.100", "Hello Everyone");

            Console.WriteLine($"Messages sent: {communicator.GetCount()}");
        }
    }
}