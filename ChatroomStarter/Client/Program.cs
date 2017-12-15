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
            List<Client> clientList = new List<Client>();
            Client client = new Client("127.0.0.1", 9999, "11"); // 127.0.0.1 ip loops back to this machine (routes traffic back to computer - communicating with self)
            clientList.Add(client);
            Invoke(clientList);
            //client.Send();
            //client.Recieve();
            //client1.Send();
            //client1.Recieve();
            Console.ReadLine();
        }
        public static void Invoke(List<Client> clientList)
        {
                while (true)
                {
                    foreach (Client client in clientList)
                    {
                    Parallel.Invoke(() =>
                    {
                        client.Send();
                    },
                    () =>
                    {
                        client.Recieve();
                    });
                    }
                }
            }
        }
    }
