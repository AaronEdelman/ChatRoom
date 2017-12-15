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
            client = Client; //dictionary values should replace this value
            UserId = "1";
        }
        public void Send(string Message)
        {
            SendMessage(Message);
            //byte[] message = Encoding.ASCII.GetBytes(Message);//converts string to bytes
            //stream.Write(message, 0, message.Count()); //writes message (bytes) to stream 
        }
        public string Recieve()
        {
            string message = RecieveMessage();
            return message;
            //byte[] recievedMessage = new byte[256];// creates empty array of bytes
            //byte[] key = new byte[256];
            //stream.Read(key, 0, 2);
            //string userIdFull = Encoding.ASCII.GetString(key);
            //UserId = userIdFull.Substring(0, 2);
            //stream.Read(recievedMessage, 0, recievedMessage.Length); //message comes in through stream (stream link created when client is instantiated in Server class), reads bytes
            //string recievedMessageString = Encoding.ASCII.GetString(recievedMessage); //converts bytes from stream into string
            //Console.Write(UserId + ": " + recievedMessageString); 
            //return recievedMessageString;
        }
        public string RecieveMessage()
        {
                while (true)
                {
                    byte[] recievedMessage = new byte[256];// creates empty array of bytes
                    byte[] key = new byte[256];
                    stream.Read(key, 0, 2);
                    string userIdFull = Encoding.ASCII.GetString(key);
                    UserId = userIdFull.Substring(0, 2);
                    stream.Read(recievedMessage, 0, recievedMessage.Length); //message comes in through stream (stream link created when client is instantiated in Server class), reads bytes
                    string recievedMessageString = Encoding.ASCII.GetString(recievedMessage); //converts bytes from stream into string
                    Console.Write(UserId + ": " + recievedMessageString);
                    return recievedMessageString;
                }
        }
        public void SendMessage(string Message)
        {
                while (true)
                {
                    byte[] message = Encoding.ASCII.GetBytes(Message);//converts string to bytes
                    stream.Write(message, 0, message.Count()); //writes message (bytes) to stream 
                }
        }
    }
}
