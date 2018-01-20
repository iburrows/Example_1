using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_1.Communication
{
    public class Server
    {
        Socket serverSocket;
        List<ClientHandler> clientList = new List<ClientHandler>();
        //Action<string> UpdateGui;

        public Server(int port)
        {
            //this.UpdateGui = updateGui;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, port));
            serverSocket.Listen(5);
            Task.Factory.StartNew(Accept);
        }

        private void Accept()
        {
            while (true)
            {
                try
                {
                    clientList.Add(new ClientHandler(serverSocket.Accept(), NewMessageReceived));
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Send(string message)
        {
            foreach (var client in clientList)
            {
                client.Send(message);
            }
        }

        private void NewMessageReceived(string message)
        {

        }
    }
}
