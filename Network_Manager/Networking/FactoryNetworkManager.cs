namespace Networking
{
    public class FactoryNetworkManager
    {
        public ICommunicator Create(string type)
        {
            if (type == "LAN")
            {
                return new EncodedTcpManager();
            }else if (type == "WIFI")
            {
                return new HttpManager();
            }
            else 
            {
                throw new ArgumentException("Invalid type specified. Use 'LAN' or 'WIFI'.");
            }
        }
    }
}
