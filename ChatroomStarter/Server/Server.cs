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
            Dictionary<int, Client> dictionary;
            Queue<Message> queue;
            public Server()
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
                server.Start();
            }
            public void Run()
            {
                queue = new Queue<Message>();
                dictionary = new Dictionary<int, Client>();
                AcceptClient();
                while (true)
            {
                string message = client.Recieve();
                Message messageObj = new Message(client, message);
                queue.Enqueue(messageObj);
                Message chat = queue.Dequeue();
                Console.WriteLine(chat.UserId + ":" + chat.Body);
                //Console.WriteLine(queue.name + ":" + message);
                Respond(message);
            }
            }
            private void AcceptClient()
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                dictionary.Add(client.key, client);
            }
            private void Respond(string body)
            {
                client.Send(body);
            }
        }
    }
