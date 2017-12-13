using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //Aaron test
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        string key = "12";// TODO: Create new NetworkStream?
        public Client(string IP, int port)
        {
            clientSocket = new TcpClient(); //provides client connections for TCP network services
            clientSocket.Connect(IPAddress.Parse(IP), port); //connects client to a remote TCP host, using IP and port provided in 'program'
            stream = clientSocket.GetStream(); //Returns the NetworkStream used to send and recieve data
        }
        public void Send()
        {
            string messageStringInput = UI.GetInput(); //takes user input from UI class
            string messageString = key + messageStringInput;
            Console.WriteLine(messageString);
            byte[] message = Encoding.ASCII.GetBytes(messageString); //converts input string to byte format
            stream.Write(message, 0, message.Count()); //copies input message (byte form) from buffer to curretn stream, '0' is where buffer starts, 'message.count' is where buffer ends.
        }
        public void Recieve()
        {
            byte[] recievedMessage = new byte[256]; //received message taken in as byte array
            stream.Read(recievedMessage, 0, recievedMessage.Length); // returns byte array of values between '0' and message length
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage)); //converts received byte array into string
        }
    }
}
