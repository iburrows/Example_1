using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_1.Communication
{
    class ClientHandler
    {
        private Socket clientSocket;
        private Action<string> NewMessageReceived;

        byte[] buffer = new byte[512];

        public ClientHandler(Socket socket, Action<string> newMessageReceived)
        {
            this.clientSocket = socket;
            this.NewMessageReceived = newMessageReceived;

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

        internal void Send(string message)
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
