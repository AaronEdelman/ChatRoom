using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 9999); //ip loops back to this machine (routes traffic back to computer - communicating with self)
            client.Send();
            client.Recieve();
            Console.ReadLine();
        }
    }
}
