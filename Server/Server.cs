using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class Server
    {
        public static List<Client> clients = new List<Client>();

        public static void NewClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                clients.Add(newClient);
                Console.WriteLine("Присоединился новый клиент: {0}", handle.RemoteEndPoint);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка с подключением клиента: {0}", ex.Message);
            }
        }
        public static void EndClient(Client client)
        {
            try
            {
                clients.Remove(client);
                Console.WriteLine("Клиент {0} отсоединился", client.UserName);
            }
            catch(Exception exp)
            {
                Console.WriteLine("Ошибка с отключением клиента {0}, {1}", client.UserName, exp.Message);
            }
        }
        public static void UpdateAllChats()
        {
            try
            {
                int countUsers = clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    clients[i].UpdateChat();
                }
            }
            catch (Exception exp) { Console.WriteLine("Ошибка с обновлением клиентов: {0}.", exp.Message); }
        }
    }
}
