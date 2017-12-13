using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        public Server()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            string message = client.Recieve();
            Respond(message);
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient); //sets clientSocket to null (where type is unknown) tcpClient by same name exists in Client.client
            clientSocket = server.AcceptTcpClient(); //nothing has called the Server() method yet, but it wants to use a built in method already.  Accepts a pending connection request
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream(); //Returns the NetworkStream used to send and recieve data
            client = new Client(stream, clientSocket); //instantiates new client on server
        }
        private void Respond(string body)
        {
             client.Send(body);
        }
    }
}
