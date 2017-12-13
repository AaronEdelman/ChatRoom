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
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73"; //dictionary values should replace this value
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);//converts string to bytes
            stream.Write(message, 0, message.Count()); //writes message (bytes) to stream 
        }
        public string Recieve()
        {
            byte[] recievedMessage = new byte[256]; // creates empty array of bytes
            stream.Read(recievedMessage, 0, recievedMessage.Length); //message comes in through stream (stream link created when client is instantiated in Server class), reads stream
            string recievedMessageString = Encoding.ASCII.GetString(recievedMessage); //converts bytes from stream into string
            Console.WriteLine(recievedMessageString); 
            return recievedMessageString;
        }
    }
}
