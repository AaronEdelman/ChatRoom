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
            Client client1 = new Client("127.0.0.1", 9999, "22");
            clientList.Add(client1);
            Invoke(clientList);
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
