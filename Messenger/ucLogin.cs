using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Messenger
{
    public partial class ucLogin : UserControl
    {
        
        public ucLogin()
        {
            InitializeComponent();
        }


        private void logButton_Click(object sender, EventArgs e)
        {
            string Name = TextBoxName.Text;
            fSend fSend = new fSend(Name);
            fSend.Show();
            this.Hide();
        }
        private void ucLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
