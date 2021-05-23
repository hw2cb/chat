using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        private string userName;
        private Socket handler;
        private Thread userThread;
        public Client(Socket socket)
        {
            handler = socket;
            userThread = new Thread(listner);
            userThread.IsBackground = true;
            userThread.Start();
        }
        public string UserName
        {
            get { return userName; }
        }
        private void listner()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    handleCommand(data);
                }
                catch { Server.EndClient(this); return; }
            }
        }
        public void End()
        {
            try
            {
                handler.Close();
                try
                {
                    userThread.Abort();
                }
                catch { } // г
            }
            catch (Exception exp) { Console.WriteLine("Ошибка End(): {0}.", exp.Message); }
        }
        private void handleCommand(string data)
        {
            if (data.Contains("#setname"))
            {
                userName = data.Split('&')[1];
                UpdateChat();
                return;
            }
            if (data.Contains("#newmsg"))
            {
                string message = data.Split('&')[1];
                ChatController.AddMessage(userName, message);
                return;
            }
        }
        public void UpdateChat()
        {
            Send(ChatController.GetChat());
        }
        public void Send(string command)
        {
            try
            {
                int bytesSent = handler.Send(Encoding.UTF8.GetBytes(command));
                if (bytesSent > 0) Console.WriteLine("Успешно");
            }
            catch (Exception exp) { Console.WriteLine("Ошибка Send(): {0}.", exp.Message); Server.EndClient(this); }
        }
    }
}
