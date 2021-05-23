using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Messenger
{
    public partial class fSend : MaterialForm
    {
        private delegate void printer(string data);
        private delegate void cleaner();
        printer Printer;
        cleaner Cleaner;
        private Socket serverSocket;
        private Thread clientThread;
        private const string serverHost = "localhost";
        private const int serverPort = 8080;
        public string userName;
        public fSend(string userName)
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearChat);

            connect();
            this.userName = userName;
            textBoxMessages.Enabled = true;
            btnSend.Enabled = true;

            textBox2.Enabled = true;
            send("#setname&" + userName);

            clientThread = new Thread(listner);
            clientThread.IsBackground = true;
            clientThread.Start();


            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(Primary.BlueGrey200, Primary.BlueGrey300, Primary.BlueGrey300, Accent.LightBlue200,
                TextShade.WHITE);
        }
        private void listner()
        {
            while (serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }
            }
        }

        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
            }
            catch
            {
                this.Hide();
            }
        }
        private void clearChat()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner);
                return;
            }
            textBoxMessages.Clear();
        }
        private void UpdateChat(string data)
        {
            //#updatechat&userName~data|username~data
            clearChat();
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);
            }
            catch { print("Связь с сервером прервалась..."); }
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
            if (textBoxMessages.Text.Length == 0)
                textBoxMessages.AppendText(msg);
            else
                textBoxMessages.AppendText(Environment.NewLine + msg);
        }
        private void fSend_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void sendMessage()
        {
            try
            {
                string data = textBox2.Text;
                if (string.IsNullOrEmpty(data)) return;
                send("#newmsg&" + data);
                textBox2.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
    }
}
