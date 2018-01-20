using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_1.TheClients
{
    public class Client
    {
        byte[] buffer = new byte[512];
        Socket clientSocket;
        Action<string> NewMessageReceived;

        public Client(int port, Action<string> newMessageReceived)
        {
            this.NewMessageReceived = newMessageReceived;

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Loopback, port));
            clientSocket = client.Client;
            Task.Factory.StartNew(Receive);
        }

        private void Receive()
        {
            string message = "";

            while (true)
            {
                int length = clientSocket.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, length);
                NewMessageReceived(message);
            }
        }
    }
}
