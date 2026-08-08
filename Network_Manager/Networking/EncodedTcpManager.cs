
namespace Networking
{
    public class EncodedTcpManager : TcpManager
    {
        private int count=0;

        public override void SendData(string address, string data)
        {
            // Encode the data before sending
            string encodedData = EncodeData(data);
            base.SendData(address, encodedData);
            count++;
            Console.WriteLine($"Sending encoded data over TCP to {address}: {encodedData}");
        }
        
        private string EncodeData(string data)
        {
            // Simple encoding
            return data.Length+"#"+data;
        }

        private string DecodeData(string encodedData)
        {
            var parts = encodedData.Split('#', 2);
            if (parts.Length == 2 && parts[0] == parts[1].Length.ToString())
            {
                return parts[1];
            }
            else
            {
                return "Invalid encoded data";
            }
        }
    }
}
