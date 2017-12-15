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
        List<Client> clientList = null;
        //public Client client;
        TcpListener server;
        Client client;
        public Server()
        {
            server = new TcpListener(IPAddress.Any, 9999);
            server.Start(); //starts listening for incoming connection requests
        }
        public void Run()
        {
            clientList = new List<Client>();
            //Accept();
            //string message = client.Recieve();
            //string message = 
            InvokeAcceptReceive();
            //Respond(message);
        }
        public void AcceptClient()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    TcpClient clientSocket = default(TcpClient); //sets clientSocket to null (where type is unknown) tcpClient by same name exists in Client.client
                    clientSocket = server.AcceptTcpClient(); //Accepts a pending connection request
                    Console.WriteLine("Connected");
                    NetworkStream stream = clientSocket.GetStream(); //Returns the NetworkStream used to send and recieve data
                    client = new Client(stream, clientSocket); //instantiates new client on server
                    clientList.Add(client);
                }
            });
        }
        private void Respond(string body)
        {
            client.Send(body);
        }
        private void InvokeAcceptReceive()
        {
            Parallel.Invoke(() =>
            {
                AcceptClient();
            },
            () =>
            {
                string message = client.RecieveMessage();
            });
        }
    }

}
