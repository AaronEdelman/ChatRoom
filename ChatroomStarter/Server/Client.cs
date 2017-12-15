using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public int key;
        public string name;
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
        }
        public string Recieve()
        {
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                string messageString = Encoding.ASCII.GetString(recievedMessage);
                string keyString = messageString.Substring(0, 2);
                key = Int32.Parse(keyString);
                string recievedMessageString = messageString.Replace("\0", "");
                string message = recievedMessageString.Replace(keyString, "");
                if (name == null)
                {
                    name = message;
                    return messageString;
                }
                else
                {
                    Console.WriteLine(message);
                    return messageString;
                }
        }

    }
}
